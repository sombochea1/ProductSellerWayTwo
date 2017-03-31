using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSellerWayTwo
{
    public static class AutoId
    {
        private static int _id;
        private static int _getLastId;

        public static int Id { get => _id; set => _id = value; }
        public static int GetLastId { get => _getLastId; set => _getLastId = value; }
    }
}
