﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TriangleTestClient.Models
{
    public class Response
    {
        public bool status { get; set; }

        public string message { get; set; }

        public string triangleDescription { get; set; }
    }
}