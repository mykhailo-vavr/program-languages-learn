#pragma once

using namespace std;

void stoogeSort(int arr[], int start, int end) {
    if (arr[start] > arr[end]) {
        swap(arr[start], arr[end]);
    }

    if (end - start + 1 > 2)  {
        int temp = (end - start + 1) / 3;
        stoogeSort(arr, start, end - temp);
        stoogeSort(arr, start + temp, end);
        stoogeSort(arr, start, end - temp);
    }
}