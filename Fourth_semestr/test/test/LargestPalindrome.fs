module LargestPalindrome

let largestPalindrome () =
    let isPalindrome str = List.ofSeq str = List.rev (List.ofSeq str)

    let rec largestPalindromeRec x y (acc:int) =
        match y with
        | 1000 -> largestPalindromeRec (x + 1) 100 acc
        | _ -> match x with
               | 1000 -> acc
               | _ -> let mult = x * y
                      if (mult > acc) && (isPalindrome (mult.ToString())) then
                        (largestPalindromeRec x (y + 1) mult)
                      else
                        largestPalindromeRec x (y + 1) acc  

    largestPalindromeRec 100 100 0