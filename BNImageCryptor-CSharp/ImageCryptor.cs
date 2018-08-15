using System;
using System.Drawing;

namespace BNImageCryptor_CSharp
{
    class ImageCryptor
    {

        private static int[] getKey(String password, int totalBlock)
        {
            int[] keyValue = new int[password.Length];
            for (int i = 0; i < keyValue.Length; i++)
            {
                keyValue[i] = password[i] + password[keyValue.Length - 1 - i] % totalBlock;
            }

            if (password.Length == totalBlock)
            {

                return getSumIndex(keyValue);
            }

            int[] g = new int[totalBlock];
            if (password.Length > totalBlock)
            {
                for (int i = 0; i < g.Length; i++)
                {
                    g[i] = keyValue[i] + keyValue[keyValue.Length - 1 - i] % totalBlock;
                }

            }
            else
            {
                for (int i = 0; i < keyValue.Length; i++)
                {
                    g[i] = keyValue[i];
                }

                for (int i = keyValue.Length; i < g.Length; i++)
                {
                    g[i] = g[Math.Abs(i - keyValue.Length) % g.Length]
                            + g[Math.Abs(keyValue.Length - (i - keyValue.Length)) % g.Length] % totalBlock;
                }

            }

            return getSumIndex(g);

        }


        private static int[] getSumIndex(int[] keyValue)
        {
            for (int i = 0; i < keyValue.Length; i++)
            {
                keyValue[i] = Math.Abs(keyValue[i] + (i % 2 == 0 ? i : -i));
            }
            return keyValue;
        }

        private static int getTotalBlock(int w, int h, int bw, int bh)
        {
		
		if((double) w%bw!=0) {
			throw new Exception(String.Format("{0} mod {1}!=0", w, bw));
		}
		if((double) h%bh!=0) {
			throw new Exception(String.Format("{0} mod {1}!=0", h, bh));
		}

        bw = w / bw;
		bh = h / bh;
		return bw* bh;
	}

	private static int[] getIndex(int[] okey, int[] nkey)
{

    int[] index = new int[okey.Length];
    for (int i = 0; i < okey.Length; i++)
    {
        for (int x = 0; x < nkey.Length; x++)
        {
            if (okey[i] == nkey[x])
            {
                index[i] = x;
                nkey[x] = -1;
                break;
            }
        }

    }

    return index;

}

public static Bitmap encrpyt(String password, int blockWidth, int blockHeight, Bitmap originalImage)
{
		
		
		    int totalBlock = getTotalBlock(originalImage.Width, originalImage.Height, blockWidth, blockHeight);
            Console.WriteLine(String.Format("Image Width:{0} Height:{1}", originalImage.Width,originalImage.Height));
            Console.WriteLine(String.Format("Block Width:{0} Height:{1}", blockWidth,blockHeight));

            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);
            int[] okey = getKey(password, totalBlock);
            int[] nkey = (int[])okey.Clone();
            Array.Sort(nkey);

            //Console.WriteLine(String.Format("Old Key:{0}",Convert.ToString(okey)));
            //Console.WriteLine(String.Format("New Key:{0}",Convert.ToString(nkey)));

            int[] index = getIndex(okey, nkey);

            //Console.WriteLine("Encrypt Block Address:{0}", Convert.ToString(index));

            int x = 0, y = 0;
            Graphics g = Graphics.FromImage(newImage);
                
		for (int i = 0; i<index.Length; i++) {


			

            int nx = index[i] % (originalImage.Width / blockWidth);
            int ny = index[i] / (originalImage.Width / blockWidth);

            nx *= blockWidth;
			ny *= blockHeight;

                Bitmap buffImg = originalImage.Clone(new Rectangle(x, y, blockWidth, blockHeight), originalImage.PixelFormat);

                Console.Write(String.Format("Copy X:{0} Y:{1} ", x, y));

                Console.WriteLine(String.Format("From {0} To {1} X:{2} Y:{3}", i, index[i], nx, ny));
                g.DrawImage(buffImg, nx, ny);

			x = x + blockWidth;
			if (x == originalImage.Width) {
				y = y + blockHeight;
				x = 0;
			}

		}

		return newImage;
	}

	public static Bitmap decrpyt(String password, int blockWidth, int blockHeight, Bitmap originalImage)
{
            int totalBlock = getTotalBlock(originalImage.Width, originalImage.Height, blockWidth, blockHeight);
            Console.WriteLine(String.Format("Image Width:{0} Height:{1}", originalImage.Width, originalImage.Height));
            Console.WriteLine(String.Format("Block Width:{0} Height:{1}", blockWidth, blockHeight));

            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);
            int[] okey = getKey(password, totalBlock);
            int[] nkey = (int[])okey.Clone();
            Array.Sort(nkey);

            //Console.WriteLine(String.Format("Old Key:{0}", Convert.ToString(okey)));
            //Console.WriteLine(String.Format("New Key:{0}", Convert.ToString(nkey)));

            int[] index = getIndex(okey, nkey);

            //Console.WriteLine("Encrypt Block Address:{0}", Convert.ToString(index));

            int x = 0, y = 0;
            Graphics g = Graphics.FromImage(newImage);

            for (int i = 0; i<index.Length; i++) {




                int nx = index[i] % (originalImage.Width / blockWidth);
                int ny = index[i] / (originalImage.Width / blockWidth);

                nx *= blockWidth;
                ny *= blockHeight;

                Bitmap buffImg = originalImage.Clone(new Rectangle(nx, ny, blockWidth, blockHeight), originalImage.PixelFormat);

                Console.Write(String.Format("Copy X:{0} Y:{1} ", x, y));

                Console.WriteLine(String.Format("From {0} To {1} X:{2} Y:{3}", i, index[i], nx, ny));

                g.DrawImage(buffImg, x, y);

                x = x + blockWidth;
			if (x == originalImage.Width) {
				y = y + blockHeight;
				x = 0;
			}

		}

		return newImage;
	}




    }



}
