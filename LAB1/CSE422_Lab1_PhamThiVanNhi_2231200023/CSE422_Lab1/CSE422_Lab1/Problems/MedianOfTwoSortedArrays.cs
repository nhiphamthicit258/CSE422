namespace CSE422_Lab1.Problems
{
    internal class MedianOfTwoSortedArrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }

            int left = 0;
            int right = nums1.Length;
            int totalLength = nums1.Length + nums2.Length;
            int half = (totalLength + 1) / 2;

            while (left <= right)
            {
                int partition1 = (left + right) / 2;
                int partition2 = half - partition1;

                int left1 = partition1 == 0 ? int.MinValue : nums1[partition1 - 1];
                int right1 = partition1 == nums1.Length ? int.MaxValue : nums1[partition1];

                int left2 = partition2 == 0 ? int.MinValue : nums2[partition2 - 1];
                int right2 = partition2 == nums2.Length ? int.MaxValue : nums2[partition2];

                if (left1 <= right2 && left2 <= right1)
                {
                    if (totalLength % 2 == 1)
                    {
                        return Math.Max(left1, left2);
                    }

                    return ((double)Math.Max(left1, left2)
                          + Math.Min(right1, right2)) / 2;
                }

                if (left1 > right2)
                {
                    right = partition1 - 1;
                }
                else
                {
                    left = partition1 + 1;
                }
            }

            return 0;
        }
    }
}
/*Ý tưởng:
* Binary Search trên mảng ngắn hơn.
* Chia hai mảng thành hai nửa.
* Tìm vị trí chia hợp lệ rồi tính median.*/