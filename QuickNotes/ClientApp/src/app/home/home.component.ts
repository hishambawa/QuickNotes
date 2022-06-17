import { Component } from '@angular/core';
import { Note } from '../notes/note';
import { NotesService } from '../notes/notes.service';
import { Response } from '../response';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {

  //notes: Array<Note> = [];
  notes: Note[] = [];
  newNote: boolean = false;

  constructor(public noteService: NotesService) { }

  ngOnInit(): void {
    this.noteService.getNotes(1).subscribe((response: Response) => {
      if (response.status == 1) {
        this.notes = response.data;
        console.log(response.data);
      }
    });
  }

  addNote(): void {
    this.newNote = true;
  }

  discardNote(): void {
    this.newNote = false;
  }

}
