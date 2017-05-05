module LargestPalindromeTests

open LargestPalindrome
open NUnit.Framework
open FsUnit
open FsCheck

[<Test>]
let ``test of largestPalindrome`` () =
    () |> largestPalindrome |> should equal 906609
