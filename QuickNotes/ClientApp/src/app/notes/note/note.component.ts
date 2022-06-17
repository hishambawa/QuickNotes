import { Component, OnInit, Input } from '@angular/core';
import { Response } from '../../response';
import { Note } from '../note';
import { NotesService } from '../notes.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.css']
})
export class NoteComponent implements OnInit {
  @Input() note!: Note;

  constructor(public noteService: NotesService) { }

  ngOnInit(): void {
  }

  deleteNote(noteId: number): void {
    if (confirm("Are you sure you want to delete this note?")) {
      if (noteId == -1) {
        location.reload();
      }
      else {
        this.noteService.deleteNote(noteId).subscribe((response: Response) => {
          if (response.status == 1) {
            location.reload();
          }
        });
      }
    }

  }

}
