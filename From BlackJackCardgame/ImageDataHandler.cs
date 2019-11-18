using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameUtilities;
using System.Drawing;
//By Ingeborg Asplund 2019
namespace BlackJackSimple
{
    /// <summary>
    /// This class handles all of the card-images used in game.
    /// </summary>
    public class ImageDataHandler
    {
        /// <summary>
        /// this methods return different images dependent on the name of the card sent in.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Image CardImage(string name)
        {
            Image cardimage = null;//instanciate the card image as null
            switch (name)
            {
                case "AceClubs":
                        cardimage = new Bitmap(Properties.Resources.c1);
                    break;
                case "2Clubs":
                    cardimage = new Bitmap(Properties.Resources.c2);
                    break;
                case "3Clubs":
                    cardimage = new Bitmap(Properties.Resources.c3);
                    break;
                case "4Clubs":
                    cardimage = new Bitmap(Properties.Resources.c4);
                    break;
                case "5Clubs":
                    cardimage = new Bitmap(Properties.Resources.c5);
                    break;
                case "6Clubs":
                    cardimage = new Bitmap(Properties.Resources.c6);
                    break;
                case "7Clubs":
                    cardimage = new Bitmap(Properties.Resources.c7);
                    break;
                case "8Clubs":
                    cardimage = new Bitmap(Properties.Resources.c8);
                    break;
                case "9Clubs":
                    cardimage = new Bitmap(Properties.Resources.c9);
                    break;
                case "10Clubs":
                    cardimage = new Bitmap(Properties.Resources.c10);
                    break;
                case "JackClubs":
                    cardimage = new Bitmap(Properties.Resources.cj);
                    break;
                case "QueenClubs":
                    cardimage = new Bitmap(Properties.Resources.cq);
                    break;
                case "KingClubs":
                    cardimage = new Bitmap(Properties.Resources.ck);
                    break;
                case "AceDiamonds":
                    cardimage = new Bitmap(Properties.Resources.d1);
                    break;
                case "2Diamonds":
                    cardimage = new Bitmap(Properties.Resources.d2);
                    break;
                case "3Diamonds":
                    cardimage = new Bitmap(Properties.Resources.d3);
                    break;
                case "4Diamonds":
                    cardimage = new Bitmap(Properties.Resources.d4);
                    break;
                case "5Diamonds":
                    cardimage = new Bitmap(Properties.Resources.d5);
                    break;
                case "6Diamonds":
                    cardimage = new Bitmap(Properties.Resources.d6);
                    break;
                case "7Diamonds":
                    cardimage = new Bitmap(Properties.Resources.d7);
                    break;
                case "8Diamonds":
                    cardimage = new Bitmap(Properties.Resources.d8);
                    break;
                case "9Diamonds":
                    cardimage = new Bitmap(Properties.Resources.d9);
                    break;
                case "10Diamonds":
                    cardimage = new Bitmap(Properties.Resources.d10);
                    break;
                case "JackDiamonds":
                    cardimage = new Bitmap(Properties.Resources.dj);
                    break;
                case "QueenDiamonds":
                    cardimage = new Bitmap(Properties.Resources.dq);
                    break;
                case "KingDiamonds":
                    cardimage = new Bitmap(Properties.Resources.dk);
                    break;
                case "AceSpades":
                    cardimage = new Bitmap(Properties.Resources.s1);
                    break;
                case "2Spades":
                    cardimage = new Bitmap(Properties.Resources.s2);
                    break;
                case "3Spades":
                    cardimage = new Bitmap(Properties.Resources.s3);
                    break;
                case "4Spades":
                    cardimage = new Bitmap(Properties.Resources.s4);
                    break;
                case "5Spades":
                    cardimage = new Bitmap(Properties.Resources.s5);
                    break;
                case "6Spades":
                    cardimage = new Bitmap(Properties.Resources.s6);
                    break;
                case "7Spades":
                    cardimage = new Bitmap(Properties.Resources.s7);
                    break;
                case "8Spades":
                    cardimage = new Bitmap(Properties.Resources.s8);
                    break;
                case "9Spades":
                    cardimage = new Bitmap(Properties.Resources.s9);
                    break;
                case "10Spades":
                    cardimage = new Bitmap(Properties.Resources.s10);
                    break;
                case "JackSpades":
                    cardimage = new Bitmap(Properties.Resources.sj);
                    break;
                case "QueenSpades":
                    cardimage = new Bitmap(Properties.Resources.sq);
                    break;
                case "KingSpades":
                    cardimage = new Bitmap(Properties.Resources.sk);
                    break;
                case "AceHearts":
                    cardimage = new Bitmap(Properties.Resources.h1);
                    break;
                case "2Hearts":
                    cardimage = new Bitmap(Properties.Resources.h2);
                    break;
                case "3Hearts":
                    cardimage = new Bitmap(Properties.Resources.h3);
                    break;
                case "4Hearts":
                    cardimage = new Bitmap(Properties.Resources.h4);
                    break;
                case "5Hearts":
                    cardimage = new Bitmap(Properties.Resources.h5);
                    break;
                case "6Hearts":
                    cardimage = new Bitmap(Properties.Resources.h6);
                    break;
                case "7Hearts":
                    cardimage = new Bitmap(Properties.Resources.h7);
                    break;
                case "8Hearts":
                    cardimage = new Bitmap(Properties.Resources.h8);
                    break;
                case "9Hearts":
                    cardimage = new Bitmap(Properties.Resources.h9);
                    break;
                case "10Hearts":
                    cardimage = new Bitmap(Properties.Resources.h10);
                    break;
                case "JackHearts":
                    cardimage = new Bitmap(Properties.Resources.hj);
                    break;
                case "QueenHearts":
                    cardimage = new Bitmap(Properties.Resources.hq);
                    break;
                case "KingHearts":
                    cardimage = new Bitmap(Properties.Resources.hk);
                    break;

            }
            return cardimage;
        }
    }
}
