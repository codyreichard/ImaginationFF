export interface GameInfo {
  home:    TeamScore;
  away:    TeamScore;
  BallPlacement:      number;
  down:    null;
  yardsTog:    null;
  clock:   null;
  posteam: null;
  note:    null;
  redzone: null;
  stadium: string;
  media:   Media;
  yl:      null;
  qtr:     null;
}

export interface TeamScore {
  score: Score;
  abbr:  string;
  to:    null;
}

export interface Score {
  quarterOne: null;
  quarterTwo: null;
  quarterThree: null;
  quarterFour: null;
  overtime: null;
  total:   null;
}

export interface Media {
  radio: Radio;
  tv:    Tv;
  sat:   null;
  sathd: null;
}

export interface Radio {
  home: null;
  away: null;
}

export enum Tv {
  Cbs = "CBS",
  Fox = "FOX",
  Nbc = "NBC",
}
