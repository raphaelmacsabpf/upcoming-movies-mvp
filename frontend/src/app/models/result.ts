import { Genre } from "./genre";

export class Result {
    constructor(
       public id: number,
       public title: string,
       public posterPath: string,
       public genres: Genre[],
       public backdropPath: string,
       public overview: string,
       public releaseDate: string
    ) {}
 }