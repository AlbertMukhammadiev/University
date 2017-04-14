module Program

let evenNumbers1 = List.sum << List.map (fun elem -> if elem % 2 = 0 then 1 else 0)

let evenNumbers2 = List.fold (fun acc elem -> if (elem % 2 = 0) then acc + 1 else acc) 0

let evenNumbers3 = List.length << List.filter (fun elem -> elem % 2 = 0)
