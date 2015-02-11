using System;
namespace AssemblyCSharp
{
	public class Player
	{
		//Player data
		private int heath;
		private int energy;
		public Player ()
		{
		}

		public void moveBlock(int x1, int y1, int x2, int y2)
		{
			Board.getInstance ().moveBlock (x1,x2,y1,y2);
			//Check match at block1, block2

		}

		// Return list block destroy
		// Check condition before
		public void useSkill(int skillNumber)
		{

			int i1 = arrayOfInt[paramInt];
			localbn1.a(localbn1.n() * (paramInt + 1) / 3, true);
			int i2;
			int i3;
			int i4;
			int i5;
			int i6;
			int i7;
			int i8;
			int i11;
			int i12;
			int i10;
			//9 skill
			switch (skillNumber) {
				case 0://fire1
					// Add attack
					//a(localbn2, localbn1.m());
					i2 = ay.a(4) + 2;
					i3 = ay.a(4) + 2;
					for (i4 = i2 + 2; i4 >= i2; i4--) {
						for (i5 = i3 + 2; i5 >= i3; i5--) {
							//Add list destroy
							//a(this.s.a(i4, i5), i4, i5, 1, 1, 1);

						}
					}
					break;
				case 1://fire2
					//a(localbn2, localbn1.m() * 3 / 2);
					i4 = 0;
					i5 = 2;
					i3 = 2;
					for (i6 = 3; i6 >= 0; i6--) {
						i4 = ay.a(4);
						i2 = i4 * 2 + 2;
						for (i7 = i2 + 1; i7 >= i2; i7--) {
							for (i8 = i3 + 1; i8 >= i3; i8--) {
								//Add list destroy
								//a(this.s.a(i7, i8), i7, i8, 1, 1, 1);
							}
						}
						if (((ay.a(2) == 0) && (i5 > 0)) || (i5 > i6)) {
							i5--;
							i4 = (i4 + 1 + ay.a(3)) % 4;
							i2 = i4 * 2 + 2;
							for (i7 = i2 + 1; i7 >= i2; i7--) {
								for (i8 = i3 + 1; i8 >= i3; i8--) {
									//Add list destroy
									//a(this.s.a(i7, i8), i7, i8, 1, 1, 1);
								}
							}
						}
						i3 += 2;
					}
					i6 = 3 + ay.a(3);
					h(i6, 4);
					break;
				case 2://fire3
					//a(localbn2, localbn1.m() * 5 / 2);
					i2 = 0;
					i3 = 2;
					// 2 block 3x3
					for (i7 = 0; i7 < 2; i7++) {
						i2 = ay.a(5) + 2;
						for (i8 = i2 + 3; i8 >= i2; i8--) {
							for (int i9 = i3 + 3; i9 >= i3; i9--) {
								//a(this.s.a(i8, i9), i8, i9, 1, 1, 1);
							}
						}
						i3 += 4;
					}
					i6 = 2;
					h(i6, 16);
					break;
				case 3://lightning1
					//a(localbn2, localbn1.m() * 8 / 10);
					for (i7 = ay.a(e.h.length); ; i7 = (i7 + 1 + ay.a(e.h.length - 2)) % e.h.length) {
						i8 = 0;
						int[][] arrayOfInt1 = this.s.e();
						for (i11 = 2; i11 < 10; i11++) {
							for (i12 = 2; i12 < 10; i12++) {
								if (arrayOfInt1[i11][i12] == i7) {
									//a(i7, i11, i12, 1, 1, 1);
									i8++;
								}
							}
						}
						if (i8 > 0) {
							break;
						}
					}
					i6 = 4 + ay.a(5);
					h(i6, 1);
					break;
				case 4://lightning2: Sheild
					this.I[i] += 6;
					localbn1.a(true);
					break;
				case 5://lightning3
					//a(localbn2, localbn1.m() * 2);

					for (i8 = 0; i8 < 8; i8 += 4) {
						for (i10 = 0; i10 < 8; i10 += 4) {
							i2 = 2 + i8 + ay.a(2);
							i3 = 2 + i10 + ay.a(2);
							for (i11 = i2 + 2; i11 >= i2; i11--) {
								for (i12 = i3 + 2; i12 >= i3; i12--) {
									//a(this.s.a(i11, i12), i11, i12, 1, 1, 1);
								}
							}
						}
					}
					i6 = 3 + ay.a(3);
					h(i6, 9);
					break;
				case 6://ice1
					//a(localbn2, localbn1.m() * 8 / 10);
					//localbn2.a(8, false);
					i5 = 0;
					i6 = ay.a(2) + 2;
					while (i5 < i6) {
						i8 = ay.a(8) + 2;
						i10 = ay.a(8) + 2;
						i11 = 1;
						for (i12 = this.z - 1; i12 >= 0; i12--) {
							if ((this.y[i12].a == i8) && (this.y[i12].b == i10)) {
								i11 = 0;
								break;
							}
						}
						if (i11 != 0) {
							a(this.s.a(i8, i10), i8, i10, 1, 1, 1);
							i5++;
						}
					}
					break;
				case 7://ice2
					//b(localbn1, localbn1.s() / 10 * 2);
					for (i8 = 2; i8 < 10; i8++) {
						for (i10 = 2; i10 < 10; i10++) {
							if (this.s.a(i8, i10) == 2) {
								//a(2, i8, i10, 1, 1, 1);
							}
						}
					}
					break;
				case 8://ice3
					//a(localbn2, localbn1.m() * 3 / 2);
					//localbn2.a(18, false);
					i5 = 0;
					i6 = ay.a(3) + 3;
					while (i5 < i6) {
						i8 = ay.a(8) + 2;
						i10 = ay.a(8) + 2;
						i11 = 1;
						for (i12 = this.z - 1; i12 >= 0; i12--) {
							if ((this.y[i12].a == i8) && (this.y[i12].b == i10)) {
								i11 = 0;
								break;
							}
						}
						if (i11 != 0) {
							a(this.s.a(i8, i10), i8, i10, 1, 1, 1);
							i5++;
						}
					}
					if (!localbn2.k()) {
						this.G += 2;
						if (this.J[j] > 0) {
							this.J[j] += 2;
						} else {
							this.J[j] += 3;
						}
					}
					break;
			}
			this.C = this.t.a(i1, i, this.y, this.z);
			bs.a().a(i1);
		}
	}
}

