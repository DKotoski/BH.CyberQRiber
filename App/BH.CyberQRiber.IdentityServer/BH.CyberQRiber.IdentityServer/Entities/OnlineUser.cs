﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BH.CyberQRiber.IdentityServer.Entities
{
    public class OnlineUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string BlockChainAddress { get; set; }
    }
}
