﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgGame
{
    class Layer
    {
        private int id;
        private int width, height;
        private int totalX, totalY;
        //private int[][] tiles;
        private BufferedImage[] gTilePalette;
        public Layer(String path, String dirImg)
        {
            loadWorld(path);
            gTilePalette = SliceImg(dirImg, width, height, totalX, totalY);
        }
        private BufferedImage[] SliceImg(String dirImg, int width, int height, int totalX, int totalY)
        {
            int cW = (int)(totalX * 1.0 / width);
            int cH = (int)(totalY * 1.0 / height);
            BufferedImage[] a = new BufferedImage[width * height];
            Sprite sheet = new Sprite(ImageLoader.loadImage(dirImg));

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    a[x + width * y] = sheet.crop(x * cW, y * cH, cW, cH);
                }
            }
            return a;
        }

        private void loadWorld(String path){
		String file = Utils.loadFileAsString(path);
		String[] tokens = file.split("\\s+");
		width = Utils.parseInt(tokens[0]);
		height = Utils.parseInt(tokens[1]);
		setTotalX(Utils.parseInt(tokens[2]));
		totalY = Utils.parseInt(tokens[3]);
		
		tiles = new int[getWidth()][getHeight()];
		for(int y = 0;y < getHeight();y++){
			for(int x = 0;x < getWidth();x++){
				tiles[x][y] = Utils.parseInt(tokens[(x + y * getWidth()) + 4]);//pensar
			}
		}
	}
        public void render(Graphics g)
        {
            int cW = (int)(getTotalX() * 1.0 / getWidth());
            int cH = (int)(totalY * 1.0 / getHeight());
            for (int y = 0; y < getHeight(); y++)
            {
                for (int x = 0; x < getWidth(); x++)
                {
                    g.drawImage(gTilePalette[getTiles()[x][y]], (int)(x * cW),
                            (int)(y * cH), cW, cH, null);
                }
            }

        }

        /**
         * @return the tiles
         */
        public int[][] getTiles()
        {
            return tiles;
        }

        /**
         * @return the width
         */
        public int getWidth()
        {
            return width;
        }

        /**
         * @return the height
         */
        public int getHeight()
        {
            return height;
        }

        /**
         * @return the totalX
         */
        public int getTotalX()
        {
            return totalX;
        }

        /**
         * @param totalX the totalX to set
         */
        public void setTotalX(int totalX)
        {
            this.totalX = totalX;
        }
  
    }
}
