using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BinaryTree;

namespace Tests_BinaryTree
{
	public class Test_IndexArray
	{

		[Fact]
		public void TestCreateWithArray_ShouldReturn_3_5_6_4_8_AtPosition_0()
		{
			// arrange
			int[] expected = new int[] { 3, 5, 6, 4, 8 };
			// act
			IndexArray<int> actual = new IndexArray<int>(expected);
			// assert

			Assert.Equal(expected, actual);
			Assert.True(actual[0] == 3);
		}
		[Fact]
		public void TestCreateWithArray_ShouldReturn_3_5_6_4_8_AtPosition_3()
		{
			// arrange
			int[] expected = new int[] { 3, 5, 6, 4, 8 };
			// act
			IndexArray<int> actual = new IndexArray<int>(3, expected);
			// assert

			Assert.Equal(expected, actual);
			Assert.True(actual[3] == 3);

		}
		[Theory]
		[InlineData(0, 0, 1)]
		[InlineData(-1, 0, 2)]
		[InlineData(100, 102, 3)]
		[InlineData(-8, -4, 5)]
		[InlineData(1, 5, 5)]
		public void TestIndexator_Get_1_2_3_4_5_6_7_8_9_StartedAt_FIRST_index_Get_SECOND_index_ShouldReturn_THIRD_value
			(int startIndex, int searchIndex, int expectedValue)
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			// act
			IndexArray<int> actual = new IndexArray<int>(startIndex, arr);
			// assert
			Assert.True(actual[searchIndex] == expectedValue);

		}

		[Theory]
		[InlineData(0, 0, 1)]
		[InlineData(-1, 0, 2)]
		[InlineData(100, 102, 3)]
		[InlineData(-8, -4, 5)]
		[InlineData(1, 5, 5)]
		public void TestIndexator_Set_1_2_3_4_5_6_7_8_9_StartedAt_FIRST_index_SetAt_SECOND_index_THIRD_value
	(int startIndex, int pasteIndex, int pastedValue)
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			// act
			IndexArray<int> actual = new IndexArray<int>(startIndex, arr);
			actual[pasteIndex] = pastedValue;
			// assert
			Assert.True(actual[pasteIndex] == pastedValue);

		}

		[Theory]
		[InlineData(0, -1)]
		[InlineData(10, 5)]
		[InlineData(0, 10)]
		[InlineData(7, 47)]
		[InlineData(-8, -9)]
		[InlineData(-9, 0)]
		public void TestIndexatorGet_1_2_3_4_5_6_7_8_9_ShouldThrow_IndexOutOfRangeException(int startIndex, int searchIndex)
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			// act
			IndexArray<int> actual = new IndexArray<int>(startIndex, arr);
			// assert
			Assert.Throws<IndexOutOfRangeException>(() => actual[searchIndex]);
		}

		[Theory]
		[InlineData(0, -1)]
		[InlineData(10, 5)]
		[InlineData(0, 10)]
		[InlineData(7, 47)]
		[InlineData(-8, -9)]
		[InlineData(-9, 0)]
		public void TestIndexatorSet_1_2_3_4_5_6_7_8_9_ShouldThrow_IndexOutOfRangeException(int startIndex, int pasteIndex)
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			// act
			IndexArray<int> actual = new IndexArray<int>(startIndex, arr);
			// assert
			Assert.Throws<IndexOutOfRangeException>(() => actual[pasteIndex] = new Random().Next());
		}

		[Theory]
		[InlineData(0)]
		[InlineData(5)]
		[InlineData(15)]
		[InlineData(1000)]
		[InlineData(8)]
		public void TestAdd_ShouldReturn_Param(int param)
		{

			IndexArray<int> arr = new IndexArray<int>();
			Random r = new Random();
			for (int i = 0; i < param; i++)
			{
				arr.Add(r.Next(0, 500));
			}

			int actual = param;
			int current = arr.Count;

			Assert.Equal(current, actual);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(5)]
		[InlineData(15)]
		[InlineData(1000)]
		[InlineData(8)]
		public void TestClear_ShouldReturn_0(int param)
		{

			IndexArray<int> arr = new IndexArray<int>();
			Random r = new Random();
			for (int i = 0; i < param; i++)
			{
				arr.Add(r.Next(0, 500));
			}
			arr.Clear();

			int actual = 0;
			int current = arr.Count;

			Assert.Equal(current, actual);
		}


		[Fact]
		public void TestContains_ShouldReturn_True()
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			IndexArray<int> index_array = new IndexArray<int>(new Random().Next(), arr);
			// act
			bool actual = index_array.Contains(4);
			// assert
			Assert.True(actual);
		}
		[Fact]
		public void TestContains_ShouldReturn_False()
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			IndexArray<int> index_array = new IndexArray<int>(new Random().Next(), arr);
			// act
			bool actual = index_array.Contains(48);
			// assert
			Assert.False(actual);

		}
		[Fact]
		public void TestRemove_ShouldReturn_True()
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			int[] expected = new int[] { 1, 2, 3, 5, 6, 7, 8, 9 };
			IndexArray<int> index_array = new IndexArray<int>(new Random().Next(), arr);
			// act
			bool actual = index_array.Remove(4);
			
			// assert
			Assert.True(actual);
			Assert.Equal(expected, index_array);
		}
		[Fact]
		public void TestRemove_ShouldReturn_False()
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			IndexArray<int> index_array = new IndexArray<int>(new Random().Next(), arr);
			// act
			bool actual = index_array.Remove(14);

			// assert
			Assert.False(actual);
			Assert.Equal(arr, index_array);

		}
		[Fact]
		public void TestRemoveAt_ShouldReturn_Without_1()
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			int[] expected = new int[] {2, 3, 4, 5, 6, 7, 8, 9 };
			IndexArray<int> index_array = new IndexArray<int>(4, arr);
			// act
			index_array.RemoveAt(4);

			// assert
			Assert.Equal(expected, index_array);

		}

		[Fact]
		public void TestRemoveAt_ShouldReturn_Without_6()
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			int[] expected = new int[] {1, 2, 3, 4, 5, 7, 8, 9 };
			IndexArray<int> index_array = new IndexArray<int>(-3, arr);
			// act
			index_array.RemoveAt(2);

			// assert
			Assert.Equal(expected, index_array);

		}

		[Fact]
		public void TestRemoveAt_ShouldThrowIndexOutOfRangeException()
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			IndexArray<int> index_array = new IndexArray<int>(3, arr);
			// act and assert
			Assert.Throws<IndexOutOfRangeException>(()=> index_array.RemoveAt(14));
		}

		[Fact]
		public void TestIncert()
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			int[] expected = new int[] {1, 2, 3, 4, 5, 6, 100, 7, 8, 9 };
			IndexArray<int> index_array = new IndexArray<int>(-3, arr);
			// act
			index_array.Insert(2, 100);

			// assert
			Assert.Equal(expected, index_array);


		}
		[Fact]
		public void TestIncert_ShouldThrowIndexOutOfRangeException()
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			IndexArray<int> index_array = new IndexArray<int>(3, arr);
			// act and assert
			Assert.Throws<IndexOutOfRangeException>(() => index_array.Insert(14, 5));

		}
		[Theory]
		[InlineData (3)]
		[InlineData (1)]
		[InlineData (8)]
		public void TestIndexOf_0_1_2_3_4_5_6_7_8_WithStartAt_5_ShouldReturn_ParamPlus5(int index)
		{
			// arrange
			int[] arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8};
			IndexArray<int> index_array = new IndexArray<int>(5, arr);
			int expected = index + 5;
			// act
			  int actual = index_array.IndexOf(index);
			// assert
			Assert.Equal(expected, actual);
		}
		[Fact]
		public void TestIndexOf_0_1_2_3_4_5_6_7_8_WithStartAt_5_ShouldReturn_Minus_1()
		{
			// arrange
			int[] arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
			IndexArray<int> index_array = new IndexArray<int>(5, arr);
			int expected = -1;
			// act
			int actual = index_array.IndexOf(10);
			// assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestEnumerator()
		{
			int[] expected = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
			IndexArray<int> actual = new IndexArray<int>(5, expected);
			// assert
			Assert.Equal(expected, actual);
		}


	}
}
