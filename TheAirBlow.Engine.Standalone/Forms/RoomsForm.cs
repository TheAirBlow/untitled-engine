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
        private GameObject currentObject;
        private bool needToUpdate = true;

        private async void RoomsForm_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | 
                ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            g = CreateGraphics();

            Move += new EventHandler(RoomsForm_MovedEvent);
            MouseDown += new MouseEventHandler(RoomsForm_MouseDownEvent);

            for (int i = 0; i < ProjectSaving.rooms.rooms.Count; i++)
            {
                listBox1.Items.Add(ProjectSaving.rooms.rooms[i].name);
            }

            for (int i = 0; i < ProjectSaving.objects.objects.Count; i++)
            {
                listBox2.Items.Add(ProjectSaving.objects.objects[i].name);
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
                        for (int i = 0; i < room.roomObjects.Count; i++)
                        {
                            if (room.roomObjects[i].x != forX) continue;
                            if (room.roomObjects[i].y != forY) continue;
                            room.roomObjects.RemoveAt(i);
                        }

                        int posX = (size * forX) + 2;
                        int posY = (size * forY) + 2;

                        if (e.Button != MouseButtons.Left)
                        {
                            g.FillRectangle(new SolidBrush(bg), new Rectangle(new Point(roomEditorX + posX, roomEditorY + posY), new Size(size, size)));
                            UpdateRoomView(false);
                            return;
                        }

                        if (currentObject == null)
                        {
                            MessageBox.Show($"Object is not selected yet!", "Untitled Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        RoomObject obj = new RoomObject();
                        obj.x = forX;
                        obj.y = forY;
                        obj.name = currentObject.name;

                        room.roomObjects.Add(obj);

                        UpdateRoomView(false);
                    }
                }
            }
        }

        private async void RoomsForm_MovedEvent(object sender, EventArgs e)
        {
            if (needToUpdate)
            {
                needToUpdate = false;
                UpdateRoomView();
                await Task.Delay(500);
                needToUpdate = true;
            }
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
            DrawGrid(Color.Black, 0, 0, (int)cellSize.Value, (int)cellWidth.Value, (int)cellHeight.Value, 2, true);
        }

        private void UpdateRoomView(bool refreshBG)
        {
            DrawGrid(Color.Black, 0, 0, (int)cellSize.Value, (int)cellWidth.Value, (int)cellHeight.Value, 2, refreshBG);
        }

        private void DrawLine(Color color, int x1, int y1, int x2, int y2, int width)
        {
            g.DrawLine(new Pen(color, width), roomEditorX + x1, roomEditorY + y1, roomEditorX + x2, roomEditorY + y2);
        }

        private async void DrawGrid(Color color, int x, int y, int size, int width, int height, int penWidth, bool refreshBG)
        {
            int originalWidth = 1110;
            int originalHeight = 675;
            int totalWidth = size * width + (penWidth * width);
            int totalHeight = size * height + (penWidth * height);

            if (originalWidth < (totalWidth + roomEditorX + 50)) Size = new Size(totalWidth + roomEditorX + 50, Size.Height);
            else if (originalHeight < (totalHeight + roomEditorY + 50)) Size = new Size(Size.Width, totalHeight + roomEditorY + 50);
            else Size = new Size(originalWidth, originalHeight);

            await Task.Delay(10);

            g = CreateGraphics();

            if (refreshBG)
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
                        int posX = (size * forX) + penWidth;
                        int posY = (size * forY) + penWidth;
                        if (room.roomObjects[i].x != forX
                            || room.roomObjects[i].y != forY) continue;
                        if (ProjectSaving.GetObjectByName(room.roomObjects[i].name) == null) return;
                        g.DrawImage(Image.FromFile(ProjectSaving.path + "\\Assets\\Sprites\\" 
                            + ProjectSaving.GetObjectByName(room.roomObjects[i].name).sprite), roomEditorX + posX, roomEditorY + posY);
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

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ProjectSaving.ObjectIndex((string)listBox2.SelectedItem);
            if (index != -1) currentObject = ProjectSaving.objects.objects[index];
        }
    }
}
