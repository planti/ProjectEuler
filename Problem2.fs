(* Project Euler 
 * problem 2:
 * Each new term in the Fibonacci sequence is generated by adding the previous two terms. 
 * By starting with 1 and 2, the first 10 terms will be:
 *
 * 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
 *
 * By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
 * find the sum of the even-valued terms.
 *)

module Problem2

(* brute force *)

// create fibonacci list and sum even terms
let listSolution =
    let rec fibonacciListUntil n l =
        match l with
        |f :: s :: r -> if f+s > n then l else fibonacciListUntil n (f+s :: l)
        |_ -> fibonacciListUntil n [1;0]

    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let result = fibonacciListUntil 4000000 [] |> List.filter (fun x -> x % 2 = 0) |> List.sum
    stopWatch.Stop()
    printfn "Problem 2 Answer = %d" result
    printfn "Elapsed ms = %f" stopWatch.Elapsed.TotalMilliseconds

//
// Like every sequence defined by a linear recurrence with constant coefficients, 
// the Fibonacci numbers have a closed-form expression: Bintet's formula
//  

let binet (n: float): float = 
    let phi = (1.0 - (sqrt 5.0)) / 2.0
    in System.Math.Round(((phi ** n) - ((-phi) ** (-n))) / (2.0 * phi - 1.0),0)

// Sequence with even terms
// odd + odd is even and odd + even is odd we can note that fib(3n) is even n = 1,2 ...

let binetSolution =
    let rec evenFib n limit =
        let value = binet (3.0 * n)
        if value > limit then 0.0
        else value + evenFib (n + 1.0) limit

    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let result = evenFib 1.0 4000000.0
    stopWatch.Stop()
    printfn "Problem 2 Answer = %d" (System.Convert.ToInt32(result))
    printfn "Elapsed ms = %f" stopWatch.Elapsed.TotalMilliseconds