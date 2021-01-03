import { HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { GameInfo } from '../models/gameinfo.model';

@Injectable({
  providedIn: 'root'
})
export class GameinfoService {

  private baseUrl = 'https://localhost:5001';

  constructor(private http: HttpClient) { }


  getGamesInfo(): Observable<Map<string, GameInfo>> {
    return this.http.get<Map<string,GameInfo>>(this.baseUrl + '/api/teams/livescores');
  }
}
