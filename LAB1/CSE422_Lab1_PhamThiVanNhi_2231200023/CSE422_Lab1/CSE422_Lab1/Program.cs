using CSE422_Lab1.Problems;


//Problem 1: 
int[] nums1 = { 1, 3 };
int[] nums2 = { 2 };

MedianOfTwoSortedArrays solution1 = new MedianOfTwoSortedArrays();

Console.WriteLine(solution1.FindMedianSortedArrays(nums1, nums2));

int[] nums3 = { 1, 2 };
int[] nums4 = { 3, 4 };

Console.WriteLine(solution1.FindMedianSortedArrays(nums3, nums4));

//Problem 2: 

DivideTwoIntegers solution2 = new DivideTwoIntegers();

Console.WriteLine(solution2.Divide(10, 3));
Console.WriteLine(solution2.Divide(7, -3));

//Problem 3: 

char[][] board =
{
    new char[] { 'A', 'B', 'C', 'E' },
    new char[] { 'S', 'F', 'C', 'S' },
    new char[] { 'A', 'D', 'E', 'E' }
};

WordSearch solution = new WordSearch();

Console.WriteLine(solution.Exist(board, "ABCCED"));
Console.WriteLine(solution.Exist(board, "SEE"));
Console.WriteLine(solution.Exist(board, "ABCB"));