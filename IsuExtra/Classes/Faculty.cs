using Isu.Tools;

namespace IsuExtra.Classes
{
    public class Faculty
    {
        private char _letterOfFaculty;

        public Faculty(char letter)
        {
            if (!char.IsLetter(letter))
            {
                throw new IsuException("Letter Of Faculty Invalid");
            }

            LetterOfFaculty = letter;
        }

        public char LetterOfFaculty { get => _letterOfFaculty; set => _letterOfFaculty = value; }
    }
}
