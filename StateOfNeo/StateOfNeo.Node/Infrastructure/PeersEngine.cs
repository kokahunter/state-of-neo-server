﻿using Neo.Network.P2P;
using StateOfNeo.Common;
using StateOfNeo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using static Akka.IO.Tcp;

namespace StateOfNeo.Node.Infrastructure
{
    public class PeersEngine
    {
        private readonly ICollection<TcpClient> PeerClients;

        public ICollection<IPEndPoint> Peers { get; private set; }

        public PeersEngine()
        {
            this.Peers = new HashSet<IPEndPoint>();
            this.PeerClients = new HashSet<TcpClient>();
        }

        public void AddNewPeers(ICollection<IPEndPoint> peers)
        {
            foreach (var peer in peers)
            {
                this.Peers.Add(peer);
            }
        }

        public async Task<ICollection<string>> CheckP2PStatus(ICollection<StateOfNeo.Data.Models.Node> nodes)
        {
            var failedAddresses = new HashSet<string>();
            foreach (var node in nodes)
            {
                try
                {
                    foreach (var address in node.NodeAddresses)
                    {
                        var peerIp = address.Ip.ToString().ToMatchedIp();
                        var weAreConnected = LocalNode.Singleton
                            .GetRemoteNodes()
                            .Any(rn => rn.Remote.Address.ToString().ToMatchedIp() == peerIp);

                        if (weAreConnected)
                        {
                            continue;
                        }

                        var endPoint = new IPEndPoint(IPAddress.Parse(peerIp), 10333);
                        Startup.NeoSystem.LocalNode.Tell(new Connect(endPoint), Startup.NeoSystem.LocalNode);

                        var weHaveConnected = LocalNode.Singleton
                            .GetRemoteNodes()
                            .Any(rn => rn.Remote.Address.ToString().ToMatchedIp() == peerIp);

                        if (weHaveConnected)
                        {
                            continue;
                        }

                        failedAddresses.Add(node.SuccessUrl);
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return failedAddresses;
        }

        public void UpdateClients()
        {
            foreach (var peer in this.Peers)
            {
                try
                {
                    var peerIp = peer.Address.ToString().ToMatchedIp();
                    var tcpClient = new TcpClient();
                    tcpClient.Connect(new IPEndPoint(IPAddress.Parse(peerIp), peer.Port));

                    if (tcpClient.Connected)
                    {
                        var asd = "";
                    }
                }
                catch (Exception ex)
                {
                    var thereIsSomething = "";
                }
            }
        }
    }
}
