using BusinessLogic.Exceptions;
using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing {
    public class ClubTest {


        private Club _club;

        [Theory()]
        [InlineData("", "")]
        public void Test_Club(string competitie, string ploeg) {
            Assert.Throws<ClubException>(() => _club = new(competitie, ploeg));
        }
    }
}
