import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { UpcomingMovies } from "../models/upcoming-movies";
 
@Injectable()
export class UpcomingMoviesService {
   constructor(private http: Http) {
      
   }
 
   getUpcomingMovies(page: number): Observable<UpcomingMovies[]> {
      return this.http.get(`http://localhost/api/upcomingmovies/${page}`)
         .map((res: Response) => res.json())
         .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
   }
}