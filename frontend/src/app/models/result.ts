export class Result {
    constructor(
       public id: number,
       public title: string,
       public posterPath: string,
       public genres: string[],
       public backdropPath: string,
       public overview: string,
       public releaseDate: string
    ) {}
 }