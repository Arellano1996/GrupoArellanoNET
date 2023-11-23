
export interface Line {
  word?: string,//palabra de la canción
  chord?: Chord//
  toShow?: boolean;
}

export interface Chord {
  chord: _Chord,//A, C, E, ''
  chordType?: ChordType,//
}


export enum ChordType {
  septima = 'septima',
  sexta = 'sexta'
}

export enum _Chord {
  C = 'c',
  D = 'd',
  E = 'e',
  F = 'f',
  G = 'g',
  A = 'a',
  B = 'b'
}
