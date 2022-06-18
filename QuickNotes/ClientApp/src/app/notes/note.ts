export class Note {
  noteId!: number;
  title: string = "Title comes here";
  content: string = "Contents of the note comes here. Click the button on the left below to save the note. --saved";
  userId!: number;

  constructor(title: string, content: string, userId: number) {
    this.title = title;
    this.content = content;
    this.userId = userId;
  }
}
