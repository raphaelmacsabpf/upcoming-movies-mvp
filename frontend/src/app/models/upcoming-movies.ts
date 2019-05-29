import { Result } from "./result";

export class UpcomingMovies {
    constructor(
        public results: Result[],
        public page: number,
        public totalPages: number
    ) {}
}