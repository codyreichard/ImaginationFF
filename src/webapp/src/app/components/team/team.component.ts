import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { NflTeams } from '../../models/team.model';
import { TeamService } from '../../services/team.service';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.scss']
})
export class TeamComponent implements OnInit {

  nfl$: Observable<NflTeams>;

  constructor(private teamService: TeamService) { }

  ngOnInit(): void {
    this.nfl$ = this.teamService.getTeams();
  }

}
