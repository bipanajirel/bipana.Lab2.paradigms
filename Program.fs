// For more information see https://aka.ms/fsharp-console-apps
printfn "Bipana Jirel"

// Define the Coach record
type Coach = { Name: string; FormerPlayer: bool }

// Define the Stats record
type Stats = { Wins: int; Losses: int }

// Define the Team record
type Team = { Name: string; Coach: Coach; Stats: Stats }

// Create a list of 5 Teams
let teams = [
    { Name = "San Antonio Spurs"; Coach = { Name = "Gregg Popovich"; FormerPlayer = false }; Stats = { Wins = 2283; Losses = 1502 } }
    { Name = "Los Angeles Lakers"; Coach = { Name = "Darvin Ham"; FormerPlayer = true }; Stats = { Wins = 3503; Losses = 2419 } }
    { Name = "Oklahoma City Thunder"; Coach = { Name = "Mark Daigneault"; FormerPlayer = false }; Stats = { Wins = 2413; Losses = 2111 } }
    { Name = "Milwaukee Bucks"; Coach = { Name = "Doc Rivers"; FormerPlayer = false }; Stats = { Wins = 2340; Losses = 2103 } }
    { Name = "Philadelphia 76ers"; Coach = { Name = "Nick Nurse"; FormerPlayer = false }; Stats = { Wins = 3054; Losses = 2805 } }
]

// Filter successful teams
let successfulTeams = List.filter (fun team -> team.Stats.Wins > team.Stats.Losses) teams
printfn "Successful Teams:"
successfulTeams |> List.iter (fun team ->
    printfn "- %s" team.Name)
// Calculate success percentage of each team

let calculateSuccessPercentage team =
    let totalGames = float (team.Stats.Wins + team.Stats.Losses)
    let successPercentage = float team.Stats.Wins / totalGames * 100.0
    successPercentage

// Map the list of successful teams to their success percentages
let successPercentages = List.map calculateSuccessPercentage successfulTeams

// Print success percentages
List.map2 (fun team percentage -> printfn "%s success percentage: %.2f%%" team.Name percentage) successfulTeams successPercentages
