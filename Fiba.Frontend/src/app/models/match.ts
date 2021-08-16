import { Team } from "./Team";

export class Match {
    matchId : number;
    date : Date;

    status : string;
    period : number;
    time : Date;
    postseason : boolean;
 
    homeTeamId : number;
    homeTeam : Team;
    homeTeamScore: number;
 
    visitorTeamId: number;
    visitorTeam : Team;
    visitorTeamScore: number;
}