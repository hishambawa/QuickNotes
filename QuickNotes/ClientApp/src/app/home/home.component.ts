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

  saveNote(): void {
    let noteTitle = (<HTMLInputElement>document.getElementById("note-title")).innerText;
    let noteContent = (<HTMLInputElement>document.getElementById("note-content")).innerHTML;

    let note = new Note(noteTitle, noteContent, 1);

    this.noteService.createNote(note).subscribe((response: Response) => {
      if (response.status == 1) {
        this.notes.push(response.data);
        this.newNote = false;
      }
    });

  }

  discardNote(): void {
    this.newNote = false;
  }

}
