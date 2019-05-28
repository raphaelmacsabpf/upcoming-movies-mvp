export class Result {
    constructor(
       public id: number,
       public title: string,
       public poster_path: string,
       public genres: string[],
       public backdrop_path: string,
       public overview: string,
       public release_date: string
    ) {}
 }