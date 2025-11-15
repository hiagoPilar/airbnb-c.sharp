using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class PasswordHash
    {
        public string Hash { get; private set; }

        private PasswordHash() { }

        public PasswordHash(string hash)
        {
            Hash = hash;
        }
    }
}
