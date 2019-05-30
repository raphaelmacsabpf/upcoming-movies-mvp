import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { UpcomingMovies } from "../models/upcoming-movies";
import { Result } from '../models/result';
 
@Injectable()
export class UpcomingMoviesService {
   public responseCache = new Map();
   public selectedUpcomingMovie: Result;
   
   constructor(private http: Http) {
      
   }
 
   getUpcomingMovies(pageId: number): Observable<UpcomingMovies> {
      const urlToFetch = `http://localhost/api/upcomingmovies/${pageId}`;

      return this.http.get(urlToFetch)
         .map((res: Response) => res.json())
         .catch((error: any) => Observable.throw(error.json().error || 'Server error'));
   }
}