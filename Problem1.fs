(* Project Euler 
 * problem 1:
 * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 
 * The sum of these multiples is 23.
 * Find the sum of all the multiples of 3 or 5 below 1000.
 *)

module Problem1


(* brute force solutions *)

// with recursive call
let explicitRcursiveSolution =
  let rec p1 i =
    if i > 999 then 0 
    else 
      if ((i % 3 = 0) || (i % 5 = 0)) then i + (p1 (i+1)) else p1 (i+1)

  let stopWatch = System.Diagnostics.Stopwatch.StartNew()
  let result = p1 3
  stopWatch.Stop()
  printfn "Problem 1 Answer = %d" result
  printfn "Elapsed ms = %f" stopWatch.Elapsed.TotalMilliseconds

// with list
let listSolution =
  let stopWatch = System.Diagnostics.Stopwatch.StartNew()
  let result = [3..999] |> List.filter (fun i -> i % 5 = 0 || i % 3 = 0) |> List.sum
  stopWatch.Stop()
  printfn "Problem 1 Answer = %d" result
  printfn "Elapsed ms = %f" stopWatch.Elapsed.TotalMilliseconds
