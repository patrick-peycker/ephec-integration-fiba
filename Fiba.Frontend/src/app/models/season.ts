import { SeasonTeam } from "./seasonTeam";

export class Season {
    seasonId: string;
    year: number;
    genderId : string;
    gender: string;
    seasonTeams: SeasonTeam[] = [];
}