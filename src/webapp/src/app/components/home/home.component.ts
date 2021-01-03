import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { GameinfoService } from 'src/app/services/gameinfo.service';
import { GameInfo } from 'src/app/models/gameinfo.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  gameInfo$: Observable<Map<string, GameInfo>>;

  constructor(private gameInfoService: GameinfoService) { }

  ngOnInit(): void {
    this.gameInfo$ = this.gameInfoService.getGamesInfo();

    this.gameInfo$.subscribe(gameInfo => console.log(gameInfo));
  }

}
