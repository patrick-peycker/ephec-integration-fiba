import { SeasonTeam } from "./seasonTeam";

export class Team {
    teamId: number;
    name: string;
    city: string;
    abbreviation: string;
    thumbUrl: string;
    genderId: string;
    gender: string;
    teamPlayers?: any;
    seasonTeams: SeasonTeam[] = [];
}