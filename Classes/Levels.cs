using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rush_Hour
{
    public struct Levels
    {
        public static readonly string[][] LevelsArray = { new string[] { "00RCB", "10DTE", "40UC6", "21RC0", "52RTD", "13DTC", "44LC2", "05UTF" }, //שלב 1    
                                                  
                                                          new string[] { "00UCB", "20RC0", "30LTC", "50RCA", "42DC7", "03LTF", "13DC6", "53LC8", "24UC2", "44LC1", "15UTE" }, //שלב 2  

                                                          new string[] { "21RC0", "31LCB", "41UC6", "52RC2", "23UTF", "35UTE" }, //שלב 3 

                                                          new string[] { "00DTF", "21RC0", "32DCB", "52LTD", "03UTE", "33RTC", "45DC6" }, //שלב 4 

                                                          new string[] { "00LCB", "10DTE", "40UC7", "21RC0", "31RTD", "03UTF", "14DTC", "44RC1", "54LCA", "05DC6", "25UC8" }, //שלב 5 

                                                          new string[] { "00LCB", "10RC2", "30LC7", "40UCA", "21RC0", "32DC1", "03DC6", "23UTC", "53RTD", "14UTF", "15DTE" }, //שלב 6 

                                                          new string[] { "01UCB", "21RC0", "02LC6", "32RC4", "13UC1", "43DC3", "04DC2", "05DC7", "25UCA" }, //שלב 7 

                                                          new string[] { "20RC0", "30RCA", "40LC3", "50LC9", "12LC6", "22UC7", "42UC4", "03RCB", "23DC1", "43LTE", "53LTC", "14UC2", "34RC8", "05DTF" }, //שלב 8 

                                                          new string[] { "20RC0", "30DTE", "01DCB", "31LTC", "02LC6", "42DC8", "13UC7", "04LC2", "14RC1", "24DTF", "25UCA", "45UC3" }, //שלב 9 

                                                          new string[] { "00LCB", "10RC7", "20UTE", "50LC8", "21RC0", "31RTC", "02DC6", "43UC1", "04RC2", "44RCA", "54RC3", "15UTF" }, //שלב 10 

                                                          new string[] { "00DTF", "01LCB", "21RC0", "32DC6", "52RTD", "03UTE", "33LTC", "45DC1" }, //שלב 11 

                                                          new string[] { "00DCB", "20RC0", "50LTD", "01LC6", "12DTE", "33RTC", "44UC2", "05UTF" }, //שלב 12 

                                                          new string[] { "00RCB", "30UTE", "21UC1", "51LC4", "02LC6", "12UC7", "23RC0", "33LCA", "43UC8", "04DC2", "44LC3", "54RC9", "15DTF" }, //שלב 13 

                                                          new string[] { "00LCB", "20DC7", "50RC9", "21DC1", "02DC6", "22RC0", "32LC3", "42DC5", "14LC2", "24UCA", "44RC8", "25DC4" }, //שלב 14 

                                                          new string[] { "10RC2", "20UTC", "01RCB", "21DTD", "51RC3", "12RC7", "22RC0", "32UC1", "03LC6", "33UCA", "53LC5", "14UTF", "44LC8", "15DTE" },  //שלב 15 

                                                          new string[] { "00LCB", "10UC7", "50RC8", "21DCA", "02RC6", "12RC1", "22UTE", "23RC0", "33RTC", "04UC2", "05DTF" }, //שלב 16 

                                                          new string[] { "00UCB", "20RC0", "30LC1", "40LTC", "50LTD", "01LTF", "12RC6", "22DC7", "33DTE", "14LC2", "44UCA", "45UC8" }, //שלב 17 

                                                          new string[] { "00RCB", "10LC2", "20UTE", "50RTD", "21RC0", "31RTC", "41LC7", "02UC6", "03DTF" }, //שלב 18 

                                                          new string[] { "21UC7", "41RTF", "02DCB", "22RC0", "32LC1", "03RC6", "14DC8", "34DCA" }, //שלב 19 

                                                          new string[] { "00UCB", "20RC0", "11LC6", "22DC7", "42DC1", "03LTF", "13UC2", "43LCA", "53LTC", "25DTE" }, //שלב 20 

                                                          new string[] { "00RCB", "10DTE", "21RC0", "31RTC", "02DC6", "03UTF", "53RTD" }, //שלב 21 

                                                          new string[] { "10UC6", "40UCA", "21RC0", "31DC7", "51LTC", "02UCB", "42RC8", "03RTF", "14LC2", "34RC1", "45UC3" }, //שלב 22 

                                                          new string[] { "02RTF", "12DCB", "32DC2", "52RTC", "13LC6", "23RC0", "33UC7", "34RC1", "44RCA", "05DTE" }, //שלב 23 

                                                          new string[] { "20DC7", "40LTF", "50LC3", "11UC2", "31RCA", "02UCB", "22RC0", "03LC6", "24UC5", "44DC4" }, //שלב 24 

                                                          new string[] { "00LCB", "10RC7", "20DTE", "21RC0", "31LTC", "41DCA", "02UC6", "43DC8", "04LC2", "24DC5", "44RC3", "54LC9" }, //שלב 25 

                                                          new string[] { "10DC6", "30UC1", "01DCB", "21RC0", "31RTD", "42UCA", "03LTF", "13DC2", "53LC3", "14UTE", "25UC7", "45UC4" }, //שלב 26 

                                                          new string[] { "00UCB", "20RC0", "01LC6", "11RC2", "22DC7", "42UCA", "03UTF", "33LC5", "53RTD", "25DTE" }, //שלב 27 

                                                          new string[] { "00RTF", "20RC0", "30UC2", "50RCA", "31UC7", "12UTE", "42LTD", "52LC8", "03DCB", "33RC1", "14RC6", "35DTC" }, //שלב 28 

                                                          new string[] { "00LTF", "20RC0", "30DC2", "50RTD", "31LC7", "41LCA", "12DCB", "33RC1", "43UC8", "04UTE", "25UC6", "45DC3" }, //שלב 29 

                                                          new string[] { "00DTF", "30LC2", "50LC5", "21RC0", "02UCB", "32LC7", "52RCA", "03RTE", "13DC6", "35DTC" }, //שלב 30 

                                                          new string[] { "00LCB", "20UC7", "40RCA", "21RC0", "32UTC", "03RTF", "13DC6", "33RC9", "53LTD", "14LC2", "25DTE" }, //שלב 31 

                                                          new string[] { "00RCB", "20RC0", "30DC7", "50RC3", "31LC1", "02DTF", "03UC6", "33LCA", "43UC4", "04RC2", "35UTE" }, //שלב 32 

                                                          new string[] { "20RC0", "30UC4", "50LTC", "01UCB", "31RC7", "41RCA", "02UTD", "33LC5", "43UC8", "04LC6", "44DC3", "35DTE" }, //שלב 33 

                                                          new string[] { "00DCB", "20RC0", "30RTC", "50RC4", "42DC1", "03RTD", "13DC6", "33UC7", "53LC3", "24UC2", "44LCA", "15UTE" }, //שלב 34 

                                                          new string[] { "20RC0", "30UC9", "50LC8", "31LTC", "41LC7", "02DTF", "03RCB", "13DC6", "43DC5", "44UCA", "05UTE" }, //שלב 35 

                                                          new string[] { "00UTF", "30LTD", "50RC8", "01RTE", "11UC6", "12LC2", "22RC0", "42UC1", "33DC7", "04LCB", "44RCA", "15DTC" }, //שלב 36 

                                                          new string[] { "00RCB", "10LC7", "20UTC", "50RC8", "21RC0", "31RTD", "02DC6", "43DC1", "04LC2", "14UTF", "44LCA", "54RC3", "15DTE" }, //שלב 37 

                                                          new string[] { "00UCB", "20RC0", "11LC6", "22DC7", "42DCA", "03RTF", "13DC2", "33LC5", "43LC8", "53RTC", "25UTD" }, //שלב 38 

                                                          new string[] { "20RC0", "30LC7", "40UCA", "41DC8", "02UCB", "22DC2", "42RC3", "52LC4", "03LTF", "13UC6", "33RC1", "25DTD" }, //שלב 39 

                                                          new string[] { "00DTF", "30LTC", "50LC3", "01RCB", "11UC2", "12DC7", "42DCA", "23RC0", "33UC5", "53RC9", "04DC6", "44LC8", "15UTE" } }; //שלב 40 








    }
}
