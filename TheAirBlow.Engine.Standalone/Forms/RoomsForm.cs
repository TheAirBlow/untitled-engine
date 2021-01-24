using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheAirBlow.Engine.Standalone.Forms
{
    public partial class RoomsForm : Form
    {
        public RoomsForm()
        {
            InitializeComponent();
        }

        private Graphics g;
        private int roomEditorX = 271;
        private int roomEditorY = 12;
        private Room room = new Room();
        private Color bg = Color.White;

        private async void RoomsForm_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            g = CreateGraphics();

            Move += new EventHandler(RoomsForm_MovedEvent);
            MouseDown += new MouseEventHandler(RoomsForm_MouseDownEvent);

            for (int i = 0; i < ProjectSaving.rooms.rooms.Count; i++)
            {
                listBox1.Items.Add(ProjectSaving.rooms.rooms[i].name);
            }

            await Task.Delay(50);

            UpdateRoomView();
        }

        private void RoomsForm_MouseDownEvent(object sender, MouseEventArgs e)
        {
            int width = (int)cellWidth.Value;
            int height = (int)cellHeight.Value;
            int size = (int)cellSize.Value;

            for (int forX = 0; forX < width; forX++)
            {
                for (int forY = 0; forY < height; forY++)
                {
                    int mouseXmin = roomEditorX + (size * forX) + 2;
                    int mouseXmax = roomEditorX + (size * (forX + 1)) + 2;
                    int mouseYmin = roomEditorY + (size * forY) + 2;
                    int mouseYmax = roomEditorY + (size * (forY + 1)) + 2;
                    if (e.X > mouseXmin && e.X < mouseXmax
                        && e.Y > mouseYmin && e.Y < mouseYmax)
                    {
                        MessageBox.Show($"Clicked at {forX + 1} / {forY + 1}" +
                            $"\nObjects are currently in development so now you only can get position");
                        for (int i = 0; i < room.roomObjects.Count; i++)
                        {
                            if (room.roomObjects[i].x != forX) continue;
                            if (room.roomObjects[i].y != forY) continue;
                            room.roomObjects.RemoveAt(i);
                        }
                    }
                }
            }
        }

        private void RoomsForm_MovedEvent(object sender, EventArgs e)
        {
            UpdateRoomView();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = (string)listBox1.SelectedItem;
            Room rm = ProjectSaving.GetRoomByName(name);
            if (rm != null)
            {
                room = rm;
                roomName.Text = name;
                cellSize.Value = room.gridSize;
                cellWidth.Value = room.gridWidth;
                cellHeight.Value = room.gridHeight;
                roomName.Text = room.name;
                bg = room.color;
            }

            UpdateRoomView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "";
            if (ProjectSaving.InputBox("Untitled Engine", "Enter new room's name:", ref name) != DialogResult.OK || name == "") return;
            if (ProjectSaving.HaveRoom(name))
            {
                MessageBox.Show("That room name is already used by another one.", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Room room = new Room();
            room.name = name;
            ProjectSaving.rooms.rooms.Add(room);
            listBox1.Items.Add(name);

            cellSize.Value = room.gridSize;
            cellWidth.Value = room.gridWidth;
            cellHeight.Value = room.gridHeight;
            roomName.Text = room.name;
            bg = room.color;

            UpdateRoomView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int index = ProjectSaving.RoomIndex((string)listBox1.SelectedItem);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                if (index != -1) ProjectSaving.rooms.rooms.RemoveAt(index);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                room.color = dialog.Color;
                bg = dialog.Color;
            }
            UpdateRoomView();
        }

        private void UpdateRoomView()
        {
            DrawGrid(Color.Black, 0, 0, (int)cellSize.Value, (int)cellWidth.Value, (int)cellHeight.Value, 2);
        }

        private void DrawLine(Color color, int x1, int y1, int x2, int y2, int width)
        {
            g.DrawLine(new Pen(color, width), roomEditorX + x1, roomEditorY + y1, roomEditorX + x2, roomEditorY + y2);
        }

        private void DrawGrid(Color color, int x, int y, int size, int width, int height, int penWidth)
        {
            int originalWidth = 1110;
            int originalHeight = 675;
            int totalWidth = size * width + (penWidth * width);
            int totalHeight = size * height + (penWidth * height);

            if (originalWidth < (totalWidth + roomEditorX + 50)) Size = new Size(totalWidth + roomEditorX + 50, Size.Height);
            else if (originalHeight < (totalHeight + roomEditorY + 50)) Size = new Size(Size.Width, totalHeight + roomEditorY + 50);
            else Size = new Size(originalWidth, originalHeight);

            g = CreateGraphics();

            g.Clear(bg);

            for (int i = 0; i <= height; i++)
            {
                int pos = (size * i) + penWidth;
                DrawLine(color, x + penWidth, pos, totalWidth - (penWidth * (width - 1)), pos, penWidth);
            }

            for (int i = 0; i <= width; i++)
            {
                int pos = (size * i) + penWidth;
                DrawLine(color, pos, y + penWidth, pos, totalHeight - (penWidth * (height - 1)), penWidth);
            }

            for (int forX = 0; forX < width; forX++)
            {
                for (int forY = 0; forY < height; forY++)
                {
                    for (int i = 0; i < room.roomObjects.Count; i++)
                    {
                        if (room.roomObjects[i].x != forX) continue;
                        if (room.roomObjects[i].y != forY) continue;
                        int posX = (size * forX) + penWidth;
                        int posY = (size * forY) + penWidth;
                        g.DrawIcon(SystemIcons.Error, roomEditorX + posX, roomEditorY + posY);
                    }
                }
            }
        }

        private void cellSize_ValueChanged(object sender, EventArgs e)
        {
            UpdateRoomView();
            room.gridSize = (int)cellSize.Value;
        }

        private void cellWidth_ValueChanged(object sender, EventArgs e)
        {
            UpdateRoomView();
            room.gridWidth = (int)cellWidth.Value;
        }

        private void cellHeight_ValueChanged(object sender, EventArgs e)
        {
            UpdateRoomView();
            room.gridHeight = (int)cellHeight.Value;
        }

        private void roomName_TextChanged(object sender, EventArgs e)
        {
            if (ProjectSaving.HaveRoom(roomName.Text)) return;
            
            room.name = roomName.Text;
        }
    }
}
