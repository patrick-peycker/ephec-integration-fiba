import { SeasonTeams } from "./seasonTeams";

export class Season {
    seasonId: string;
    year: number;
    genderId : string;
    gender: string;
    seasonTeams: SeasonTeams[]
}