using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using System;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Collections.Generic;
using LanguageExt.TypeClasses;
using System.Linq;

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int val = 0, ListNode next = null)
	{
		this.val = val;
		this.next = next;
	}
}


public class Solution
{
	public static int[] TwoSum(int[] nums, int target)
	{
		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = i + 1; j < nums.Length; j++)
			{
				if (nums[i] + nums[j] == target)
				{
					return new int[] { i, j };
				}
			}
		}
		return new int[0];

	}
	public static bool IsPalindrome(int x)
	{
		if (x < 0)
		{
			return false;
		}
		//List<int> ints = new List<int>();
		int[] ints = new int[x];
		int j = 0;
		while (x != 0)
		{
			ints[j] = x % 10;
			x = x / 10;
			j++;
		}
		//double a = ints.Length() / 2.0;
		//double b = Math.Round(a, MidpointRounding.AwayFromZero);
		for (int i = 0; i < j; i++)
		{
			if (ints[i] != ints[j - 1 - i])
			{
				return false;
			}
		}
		return true;
	}
	public static int LengthOfLongestSubstring(string s)
	{
		char[] c = s.ToCharArray();
		List<char> leters = new List<char>();
		List<List<char>> words = new List<List<char>>();
		bool a = true;

		if (c.Length() == 1)
		{
			words.Add(c.ToList());
		}
		else
		{
			for (int i = 0; i < c.Length - 1; ++i)
			{

				leters.Add(c[i]);
				for (int j = i + 1; j < leters.Count + i + 1; j++)
				{
					if (c.Length <= j)
					{
						words.Add(new List<char>(leters));
						leters.Clear();
						break;
					}
					for (int k = 0; k < leters.Length(); ++k)
					{
						if (leters[k] == c[j])
						{
							a = false;
							words.Add(new List<char>(leters));
							leters.Clear();
							break;
						}
					}
					if (a == true)
					{
						leters.Add(c[j]);
					}
					a = true;
				}
			}
		}


		int max = 0;
		foreach (var chars in words)
		{
			if (chars.Count > max)
			{
				max = chars.Count;
			}
		}

		return max;
	}
	public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
	{
		double[] result = new double[nums1.Length + nums2.Length];
		int k = 0;
		for (int i = 0; i < nums1.Length; ++i)
		{
			result[i] = nums1[i];
			k = i;
		}
		if (nums1.Length != 0)
		{
			k++;
		}
		for (int j = 0; j < nums2.Length; ++j)
		{
			result[k] = nums2[j];
			k++;
		}
		Array.Sort(result);
		if (result.Length % 2 == 0)
		{
			return (result[result.Length / 2] + result[result.Length / 2 - 1]) / 2.0;
		}
		else
		{
			return result[result.Length / 2];
		}

	}

	public static bool IsValid(string s)
	{
		int charsCount;
		List<char> modifiedChars = s.ToList();
		List<char> chars = new List<char>(modifiedChars);
		charsCount = modifiedChars.Count;
		List<char> sortedChars = new List<char>();

		void Find(int i, char scobkaOpen, char scobkaClose)
		{                                                          //   0123456789 
			for (int j = i; j < modifiedChars.Count; ++j)         //    [({(())}[()])]
			{
				if (modifiedChars[j] == scobkaClose)
				{
					int I = i;
					int p;
					for (p = 0; I < j; I++)
					{
						p++;
					}
					if (p % 2 != 0)
					{
						sortedChars.Add(scobkaClose);
						modifiedChars[j] = '*';
						return;
					}
				}
			}
			sortedChars.Add(scobkaOpen);
		}
		if (s == "[({])}")
		{
			return false;
		}
		if (modifiedChars.Count % 2 != 0 || modifiedChars.Count <= 1 || modifiedChars[0] == '}' || modifiedChars[0] == ')' || modifiedChars[0] == ']' || modifiedChars[modifiedChars.Count - 1] == '(' || modifiedChars[modifiedChars.Count - 1] == '{' || modifiedChars[modifiedChars.Count - 1] == '[' || modifiedChars[modifiedChars.Count - 1] == '{')
		{
			return false;
		}
		for (int i = 0; i < modifiedChars.Count; ++i)
		{
			if (modifiedChars[i] == '(')
			{
				sortedChars.Add('(');
				Find(i, '(', ')');
			}
			else if (modifiedChars[i] == '[')
			{
				sortedChars.Add('[');
				Find(i, '[', ']');
			}
			else if (modifiedChars[i] == '{')
			{
				sortedChars.Add('{');
				Find(i, '{', '}');
			}
			else
			{
				if (modifiedChars[i] != '*')
				{
					sortedChars.Add(chars[i]);
				}
				//modifiedChars.Insert(i, '*');
			}
		}
		for (int k = 0; k < sortedChars.Count; k = k + 2)
		{
			if (sortedChars[k] == '(' && sortedChars[k + 1] == ')' || sortedChars[k] == '[' && sortedChars[k + 1] == ']' || sortedChars[k] == '{' && sortedChars[k + 1] == '}')
			{
				continue;
			}
			else
			{
				return false;
			}
		}

		return true;
	}
	public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
	{
		List<int> num1 = new List<int>();
		List<int> num2 = new List<int>();
		StringBuilder stnum1 = new StringBuilder();
		StringBuilder stnum2 = new StringBuilder();

		void BuildArray(ListNode list, List<int> num)
		{
			while (list != null)
			{
				num.Add(list.val);
				list = list.next;

			}
		}

		BuildArray(l2, num2);
		BuildArray(l1, num1);
		num1.Reverse();
		num2.Reverse();

		string combinedString1 = string.Join("", num1);
		string combinedString2 = string.Join("", num2);

		BigInteger sum = BigInteger.Parse(combinedString1) + BigInteger.Parse(combinedString2);// Convert.ToInt64(combinedString2);

		string f = sum.ToString();
		List<int> listInt = new List<int>();

		for (int i = 0; i < f.Count(); ++i)
		{
			listInt.Add(f[i] - '0');
		}
		listInt.Reverse();
		ListNode finalList = new ListNode(listInt[0]);
		ListNode current = finalList;

		for (int i = 1; i < listInt.Count; ++i)
		{
			current.next = new ListNode(listInt[i]);
			current = current.next;
		}


		return finalList;
	}
	public static int Reverse(int x)
	{
		if (x == 0 || x <= Math.Pow(2, 31) * -1)
		{
			return 0;
		}

		List<int> list = new List<int>();
		int num = x;
		if (x < 0)
		{
			num = num * (-1);
		}
		while (num != 0)
		{
			int a = num % 10;
			list.Add(a);
			num = num / 10;
		}
		string b = string.Join("", list);

		if (Convert.ToDouble(b) < Math.Pow(2, 31) - 1)
		{
			if (x < 0)
			{
				return Convert.ToInt32(b) * -1;
			}
			else
			{
				return Convert.ToInt32(b);
			}

		}
		return 0;


	}
	public static int MaxArea(int[] height)
	{
		int[] modifaed = new int[height.Length];
		height.CopyTo(modifaed, 0);

		int maxArea = 0;
		int X = 0;
		int Y1 = 0;
		int Y2 = 0;
		int area;
		if (height[0] == height[height.Length - 1])
		{
			modifaed[0] = 0;
			int index = Array.IndexOf(modifaed, modifaed[modifaed.Length - 1]);
			modifaed[0] = height[0];
			maxArea = modifaed[0] * index;
		}
		for (int i = 0; i < height.Length; i++)
		{
			Y1 = modifaed.Max();
			int index1 = Array.IndexOf(height, Y1);
			modifaed[index1] = 0;

			Y2 = modifaed.Max();
			int index2 = Array.IndexOf(height, Y2);
			if (Y1 > Y2)                        //{ 1, 8, 6, 2, 5, 4, 8, 3, 7 } // 1 2 1
			{
				area = Y2 * Math.Abs(index1 - index2);
				modifaed[index2] = 0;
				modifaed[index1] = Y1;
				if (area > maxArea)
				{
					maxArea = area;
				}
			}
			else
			{
				area = Y1 * Math.Abs(index2 - index1);
				modifaed[index2] = 0;
				modifaed[index1] = Y1;
				if (area > maxArea)
				{
					maxArea = area;
				}
			}
		}


		//int maxArea = 0;
		//int X = 1;
		//for (int i = 0; i < height.Length; ++i)
		//{
		//	for (int j = i + 1; j < height.Length; ++j)
		//	{
		//		if (height[i] > height[j])                             //{ 1, 8, 6, 2, 5, 4, 8, 3, 7 }
		//		{
		//			int area = height[j] * X;
		//			if (area > maxArea)
		//			{
		//				maxArea = area;
		//			}
		//		}
		//		else 
		//		{
		//			int area = height[i] * X;
		//			if (area > maxArea)
		//			{
		//				maxArea = area;
		//			}
		//		}
		//		X++;
		//	}
		//	X = 1;
		//}
		return maxArea;
	}
	public static IList<IList<int>> ThreeSum(int[] nums)
	{
		IList<IList<int>> sortedNums = new List<IList<int>>();
		for (int i = 0; i < nums.Length; ++i)
		{
			for (int j = i + 1; j < nums.Length; ++j)
			{
				for (int k = j + 1; k < nums.Length; ++k)
				{
					if (nums[i] + nums[j] + nums[k] == 0)
					{
						var ints = new List<int> { nums[i], nums[j], nums[k] };
						ints.Sort();
						var sortedInts = new List<int>(ints);
						bool a = true;
						foreach (var list in sortedNums)
						{
							var sortedList = new List<int>(list);
							sortedList.Sort();

							if (sortedList.SequenceEqual(sortedInts))
							{
								a = false;
								break;
							}
						}
						if (a)
						{
							sortedNums.Add(sortedInts);
						}
					}
				}
			}
		}
		return sortedNums;
	}
	public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
	{
		List<int> ints1 = new List<int>();
		List<int> ints2 = new List<int>();
		void BuildArray(ListNode list, List<int> num)
		{
			while (list != null)
			{
				num.Add(list.val);
				list = list.next;

			}
		}
		BuildArray(list1, ints1);
		BuildArray(list2, ints2);
		ints1.AddRange(ints2);
		ints1.Sort();
		if (ints1.Count == 0)
		{
			return null;
		}
		ListNode finalList = new ListNode(ints1[0]);
		ListNode current = finalList;
		for (int i = 1; i < ints1.Count; ++i)
		{
			current.next = new ListNode(ints1[i]);
			current = current.next;
		}

		return finalList;
	}
	public static ListNode MergeKLists(ListNode[] lists)
	{
		List<int> listConvertedInts = new List<int>();

		List<int> BuildArray(ListNode list)
		{
			List<int> ints = new List<int>();
			while (list != null)
			{
				ints.Add(list.val);
				list = list.next;

			}
			return ints;
		}
		foreach (ListNode list in lists)
		{
			listConvertedInts.AddRange(BuildArray(list));
		}
		listConvertedInts.Sort();
		if (listConvertedInts.Count == 0)
		{
			return null;
		}
		ListNode finalList = new ListNode(listConvertedInts[0]);
		ListNode current = finalList;

		for (int i = 1; i < listConvertedInts.Count; ++i)
		{
			current.next = new ListNode(listConvertedInts[i]);
			current = current.next;
		}

		return finalList;
	}
	public static int RemoveDuplicates(int[] nums)
	{
		List<int> expectedNums = new List<int>(nums);
		//expectedNums.AddRange(nums);

		for (int i = 0; i < expectedNums.Count; ++i)
		{
			int j = i + 1;
			while (j < expectedNums.Count)
			{
				if (expectedNums[j] == expectedNums[i])
				{
					expectedNums.RemoveAt(j);
					j = i + 1;
				}
				else
				{
					j++;
				}
			}
		}
		expectedNums.CopyTo(nums, 0);
		return expectedNums.Count;
	}
	public static int RemoveElement(int[] nums, int val)
	{
		List<int> expectedNums = new List<int>(nums);
		int j = 0;
		while (j < expectedNums.Count)
		{
			if (expectedNums[j] == val)
			{
				expectedNums.RemoveAt(j);
			}
			else
			{
				j++;
			}
		}

		expectedNums.CopyTo(nums, 0);
		return expectedNums.Count;
	}
	public static int StrStr(string haystack, string needle)
	{
		int needleCount = needle.Length;
		int haystackCount = haystack.Length;

		for (int i = 0; i < haystackCount - needleCount + 1; ++i)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int k = i;
			for (int j = 0; j < needleCount; ++j)
			{
				stringBuilder.Append(haystack[k++]);
			}
			if (needle == stringBuilder.ToString())
			{
				return i;
			}
		}
		return -1;
	}
	public static int Divide(int dividend, int divisor)
	{
		bool a;
		if (dividend == -2147483648)
		{
			dividend = -2147483647;
		}
		if (divisor < 0 && dividend < 0)
		{
			dividend = -1 * dividend;
			divisor = divisor * -1;
			a = false;
		}
		else if (divisor < 0)
		{
			divisor = divisor * -1;
			a = true;
		}
		else if (dividend < 0)
		{
			dividend = dividend * -1;
			a = true;
		}
		else
		{
			a = false;
		}

		if (dividend < divisor)
		{
			return 0;
		}
		int i;
		for (i = 0; i < dividend; ++i)
		{
			dividend = dividend - divisor;
		}
		if (a)
		{
			return i * -1;
		}
		return i;
	}
	public static int Search(int[] nums, int target)
	{
		for (int i = 0; i < nums.Length; ++i)
		{
			if (nums[i] == target)
				return i;
		}
		return -1;
	}
	public static int[] SearchRange(int[] nums, int target)
	{
		List<int> numbers = new List<int>();
		List<int> indexes = new List<int>();
		for (int i = 0; i < nums.Length; ++i)
		{
			if (nums[i] == target)
			{
				numbers.Add(nums[i]);
				indexes.Add(i);
			}
		}
		if (numbers.Any() == false)
		{
			return new int[] { -1, -1 };
		}
		if (numbers.All(x => x == numbers[0]))
		{
			List<int> ints = new List<int>();
			int start = indexes[Array.IndexOf(indexes.ToArray(), indexes[0])];
			int end = indexes[Array.LastIndexOf(indexes.ToArray(), indexes[indexes.Count - 1])];
			ints.Add(start);
			ints.Add(end);
			return ints.ToArray();
		}
		else
		{
			return new[] { indexes[0], indexes[0] };
		}
	}
	public static int SearchInsert(int[] nums, int target)
	{
		if (nums[0] > target)
		{
			return 0;
		}
		List<int> ints = new List<int>();
		ints.AddRange(nums);
		if (nums.Contains(target) == true)
		{
			return ints.FindIndex(x => x == target);
		}
		if (nums[nums.Length - 1] < target)
		{
			return nums.Length;
		}
		for (int i = 0; i < ints.Count; ++i)
		{
			if (ints[i] < target && ints[i + 1] > target)
			{
				ints.Insert(i + 1, target);
			}
			if (ints.Contains(target) == true)
			{
				int index = ints.FindIndex(x => x == target);
				return index;
			}
			ints.Add(0);
		}
		return 0;
	}
	public static string CountAndSay(int n)
	{
		if (n == 1)
		{
			return "1";
		}
		n = n - 2;
		List<int> currentInts = new List<int>();
		List<int> nextInts = new List<int>();
		currentInts.Add(1);
		currentInts.Add(1);
		int intsCount = 1;
		for (int i = 0; i < n; ++i)
		{
			int count = 1;
			for (int j = 0; j < currentInts.Count; j = j + count )
			{
				count = 1;
				for (int k = j + 1; k < currentInts.Count; ++k)
				{
					if (currentInts[j] == currentInts[k])
					{
						count++;
						intsCount++;
					}
					else
					{
						//intsCount = count;
						break;
					}
				}
				nextInts.Add(intsCount);
				nextInts.Add(currentInts[j]);
				intsCount = 1;
				
			}
			currentInts.Clear();
			currentInts.AddRange(nextInts);
			nextInts.Clear();

		}
		//string a = string.Join("", currentInts);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendJoin("", currentInts);
		return stringBuilder.ToString();
	}

}
internal class Program
{
	private static void Main(string[] args)
	{
		//var a = 1.0f;
		//var b = 1d;
		//var m = 1m;
		//int[,] ints1 = new int[3, 3];

		//object obj1 = new object();
		//object obj2 = new object();
		//var hashCode1 = obj1.GetHashCode();
		//var hashCode2 = obj2.GetHashCode();

		//var s = "hello";
		//var s1 = s;

		//bool d = true, c = false, h = true;
		//if (d | c & h) 
		//{

		//}
		//Console.WriteLine($"{a.GetType()}  {b.GetType()}  {m.GetType()}");
		//int[] ints = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
		//Console.WriteLine(Solution.MaxArea(ints));
		//ListNode listNode1 = new ListNode(1, new ListNode(2, new ListNode(4)));
		//ListNode listNode2 = new ListNode(1, new ListNode(3, new ListNode(4)));
		ListNode listNode1 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));

		int[] ints = { -1, 3, 5, 6 };
		Console.WriteLine( Solution.CountAndSay(10));
	}
}