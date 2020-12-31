import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NflTeams } from '../models/team.model';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  private baseUrl = 'https://localhost:5001';

  constructor(private http: HttpClient) { }

  getTeams(): Observable<NflTeams> {
    return this.http.get<NflTeams>(this.baseUrl + '/api/teams');
  }
}
