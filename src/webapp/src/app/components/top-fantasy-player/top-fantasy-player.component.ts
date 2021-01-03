import { INT_TYPE } from '@angular/compiler/src/output/output_ast';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-top-fantasy-player',
  templateUrl: './top-fantasy-player.component.html',
  styleUrls: ['./top-fantasy-player.component.scss']
})
export class TopFantasyPlayerComponent implements OnInit {

  @Input()
  teamName;


  playerOne: string = "Baker Mayfield";
  constructor() { }

  ngOnInit(): void {
  }

}
