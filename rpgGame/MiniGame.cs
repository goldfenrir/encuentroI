using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgGame
{
    class MiniGame : State
    {
        private int id;
        private Object game;

        public void render()
        {

        }
        public void update()
        {

        }
        public void onEnter()
        {

        }
        public void onExit()
        {

        }

        /**
         * @return the id
         */
        public int getId()
        {
            return id;
        }

        /**
         * @param id the id to set
         */
        public void setId(int id)
        {
            this.id = id;
        }

        /**
         * @return the game
         */
        public Object getGame()
        {
            return game;
        }

        /**
         * @param game the game to set
         */
        public void setGame(Object game)
        {
            this.game = game;
        }
    }
}
