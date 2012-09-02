using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using JabbR.Client;
using JabbR.Client.Models;

namespace Jabbr.GitHub
{
    public class JabbrSend : IJabbrSend
    {
        public void Send(JabbrCommand command)
        {
            var client = new JabbRClient(command.Host);

            var connect = Connect(client, command);
            connect.ContinueWith(c =>
                                     {
                                         client.GetUserInfo()
                                             .ContinueWith(u => BroadCastToRooms(command, u, client));
                                     });
        }

        private void BroadCastToRooms(JabbrCommand command, Task<User> u, JabbRClient client)
        {
            var user = u.Result;

            foreach (string room in command.Rooms)
                SendMessagesToRoom(command, client, user, room);
        }

        private void SendMessagesToRoom(JabbrCommand command, JabbRClient client, User user, string roomName)
        {
            client.GetRoomInfo(roomName).
                ContinueWith(r =>
                                 {
                                     Room info = r.Result;
                                     bool userInRoom = info.Users.Any(usr => usr.Name == user.Name);

                                     if (userInRoom)
                                     {
                                         Send(client,roomName, command.GetMessages());
                                         return;
                                     }

                                     Action leave = () => client.LeaveRoom(roomName);

                                     client.JoinRoom(roomName)
                                         .ContinueWith(j => Send(client, roomName, command.GetMessages(), leave));
                                 });
        }

        private void Send(JabbRClient client, string room, IList<string> messages, Action callback = null)
        {
            if (!messages.Any())
            {
                if (callback == null)
                    return;

                callback();
                return;
            }

            string message = messages[0];
            messages.RemoveAt(0);

            client.Send(message, room)
                .ContinueWith(t => Send(client, room, messages, callback));
        }

        private Task<LogOnInfo> Connect(JabbRClient client, JabbrCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.UserId))
                return client.Connect(command.Username, command.Password);

            return client.Connect(command.UserId);
        }
    }
}