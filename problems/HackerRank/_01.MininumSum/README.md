*Minimum Sum
This problem was given to me in an interview with SBTech in HackerRank,
alongside with 79.Minimum-Window problem

I don't have the exact problem description but it goes something like this:
There's an input array with integers say [10, 20, 7], and a number **k** operations.
For each operation you must take the ceiling of a single number in the array / 2.
Math.Ceiling(n / 2), and replace the old number with the new one. You have to choose such numbers so 
that the end sum is the smallest possible. Example

input: [10, 20, 7]
k: 4

------- k = 1 -------
[10, 20, 7] => [10, 10, 7] // we take 20, divide by 2, and take the ceiling, so 10

------- k = 2 -------
[10, 10, 7] => [10, 5, 7] // Math.Ceiling(10 / 2) = 5

------- k = 3 -------
[10, 5, 7] => [5, 5, 7] // Math.Ceiling(10 / 2) = 5

------- k = 4 -------
[5, 5, 7] => [5, 5, 4] // Math.Ceiling(7 / 2) = 4

So we have to print out '14' since this is the sum of all numbers
