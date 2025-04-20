using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuQuan.Forms
{
    public partial class DeviceForm : Form //-------------------------------------------- THIẾT BỊ ---------------------------------------------------------------
    {
        private DeviceBLL deviceBLL;
        private List<DeviceDTO> deviceList;
        private string imagePath = "";
        private bool isEditing = false;

        public DeviceForm()
        {
            InitializeComponent();
            deviceBLL = new DeviceBLL();
            LoadDevices();
            SetupStatusComboBox();

            // Ẩn nút Lưu khi khởi động form
            btnSave.Visible = false;
        }

        // Load dữ liệu lên dataGridView
        void LoadDevices()
        {
            try
            {
                deviceList = deviceBLL.getAll();

                // Tạo DataTable để hiển thị dữ liệu
                DataTable dt = new DataTable();
                dt.Columns.Add("DeviceID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Image", typeof(string));
                dt.Columns.Add("Status", typeof(string)); // Lưu ý: Đã chuyển sang kiểu string
                dt.Columns.Add("CreatedAt", typeof(DateTime));

                // Thêm dữ liệu vào DataTable
                foreach (DeviceDTO device in deviceList)
                {
                    string statusText = device.Status == 1 ? "Hoạt động" : "Không hoạt động";
                    dt.Rows.Add(device.DeviceID, device.Name, device.Image, statusText, device.CreatedAt);
                }

                dataGridView1.DataSource = dt;

                // Đặt tiêu đề cho các cột
                dataGridView1.Columns["DeviceID"].HeaderText = "Mã thiết bị";
                dataGridView1.Columns["Name"].HeaderText = "Tên thiết bị";
                dataGridView1.Columns["Image"].HeaderText = "Hình ảnh";
                dataGridView1.Columns["Status"].HeaderText = "Trạng thái";
                dataGridView1.Columns["CreatedAt"].HeaderText = "Ngày tạo";

                // Định dạng cột ngày tạo
                dataGridView1.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Thêm cột hình ảnh
                if (!dataGridView1.Columns.Contains("ImagePreview"))
                {
                    DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                    imgColumn.HeaderText = "Hình ảnh";
                    imgColumn.Name = "ImagePreview";
                    imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dataGridView1.Columns.Add(imgColumn);
                }

                // Load hình ảnh cho mỗi dòng
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string imagePath = row.Cells["Image"].Value?.ToString();
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        try
                        {
                            Image img = Image.FromFile(imagePath);
                            row.Cells["ImagePreview"].Value = img;
                        }
                        catch
                        {
                            row.Cells["ImagePreview"].Value = null;
                        }
                    }
                }

                // Ẩn cột đường dẫn hình ảnh gốc
                dataGridView1.Columns["Image"].Visible = false;

                // Định dạng DataGridView
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thiết bị: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            // Định dạng tiêu đề cột
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            // Định dạng các dòng
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            // Định dạng đường viền
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.FromArgb(230, 230, 230);

            // Định dạng cột trạng thái
            dataGridView1.Columns["Status"].DefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Status"].Value.ToString() == "Hoạt động")
                {
                    row.Cells["Status"].Style.BackColor = Color.FromArgb(40, 167, 69);
                }
                else
                {
                    row.Cells["Status"].Style.BackColor = Color.FromArgb(220, 53, 69);
                }
            }
        }

        private void SetupStatusComboBox()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Hoạt động");
            cboStatus.Items.Add("Không hoạt động");
            cboStatus.SelectedIndex = 0;
        }

        // Hàm này có chức năng khi click nào một dòng bất kỳ sẽ cho ra từng giá trị ở từng textBox
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy ID thiết bị từ dòng được chọn
                int deviceID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["DeviceID"].Value);

                // Tìm thiết bị trong danh sách
                DeviceDTO selectedDevice = deviceList.FirstOrDefault(d => d.DeviceID == deviceID);

                if (selectedDevice != null)
                {
                    txtDeviceID.Text = selectedDevice.DeviceID.ToString();
                    txtName.Text = selectedDevice.Name;

                    // Đặt trạng thái
                    cboStatus.SelectedIndex = selectedDevice.Status == 1 ? 0 : 1;

                    dtpCreatedAt.Value = selectedDevice.CreatedAt;

                    txtImage.Text = selectedDevice.Image;

                    if (!string.IsNullOrEmpty(selectedDevice.Image) && File.Exists(selectedDevice.Image))
                    {
                        try
                        {
                            picPreview.Image = Image.FromFile(selectedDevice.Image);
                        }
                        catch
                        {
                            picPreview.Image = null;
                        }
                    }
                    else
                    {
                        picPreview.Image = null;
                    }

                    imagePath = "";  // Reset đường dẫn hình ảnh mới

                    // Hiển thị nút Sửa và Xóa, ẩn nút Lưu
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    isEditing = false;
                }
            }
        }

        // Xử lý trong Button Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            isEditing = false;

            // Hiển thị nút Lưu, ẩn nút Sửa và Xóa
            btnSave.Visible = true;
            btnEdit.Visible = false;
            btnDelete.Visible = false;

            // Focus vào ô tên thiết bị
            txtName.Focus();
        }

        // Xử lý trong Button Sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDeviceID.Text))
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditing = true;

            // Hiển thị nút Lưu, ẩn nút Sửa và Xóa
            btnSave.Visible = true;
            btnEdit.Visible = false;
            btnDelete.Visible = false;

            // Focus vào ô tên thiết bị
            txtName.Focus();
        }

        // Xử lý trong Button Lưu
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string finalImagePath = txtImage.Text;

                // Nếu đã chọn hình ảnh mới, lưu vào thư mục ứng dụng
                if (!string.IsNullOrEmpty(imagePath))
                {
                    string fileName = Path.GetFileName(imagePath);
                    string destPath = Path.Combine(Application.StartupPath, "Images", fileName);

                    // Tạo thư mục nếu chưa tồn tại
                    Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Images"));

                    // Sao chép tệp hình ảnh
                    File.Copy(imagePath, destPath, true);
                    finalImagePath = destPath;
                }

                // Tạo đối tượng thiết bị
                int status = cboStatus.SelectedIndex == 0 ? 1 : 0;
                bool result = false;

                if (isEditing)
                {
                    // Cập nhật thiết bị
                    int deviceID = int.Parse(txtDeviceID.Text);
                    DeviceDTO device = new DeviceDTO(
                        deviceID,
                        txtName.Text,
                        finalImagePath,
                        status,
                        dtpCreatedAt.Value
                    );

                    result = deviceBLL.update(device);

                    if (result)
                    {
                        MessageBox.Show("Cập nhật thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thiết bị thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // Thêm thiết bị mới
                    DeviceDTO device = new DeviceDTO(
                        0, // ID sẽ được tạo tự động trong cơ sở dữ liệu
                        txtName.Text,
                        finalImagePath,
                        status,
                        dtpCreatedAt.Value
                    );

                    result = deviceBLL.create(device);

                    if (result)
                    {
                        MessageBox.Show("Thêm thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thiết bị thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Làm mới form và tải lại dữ liệu
                LoadDevices();
                ClearForm();

                // Hiển thị lại nút Sửa và Xóa, ẩn nút Lưu
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                isEditing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý trong Button Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDeviceID.Text))
                {
                    MessageBox.Show("Vui lòng chọn thiết bị cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int deviceID = int.Parse(txtDeviceID.Text);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thiết bị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = deviceBLL.delete(deviceID);

                    if (success)
                    {
                        MessageBox.Show("Xóa thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDevices();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thiết bị thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp",
                Title = "Chọn hình ảnh thiết bị"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                txtImage.Text = imagePath;

                try
                {
                    picPreview.Image = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();

            // Hiển thị lại nút Sửa và Xóa, ẩn nút Lưu
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;
            isEditing = false;
        }

        private void ClearForm()
        {
            txtDeviceID.Text = "";
            txtName.Text = "";
            cboStatus.SelectedIndex = 0;
            dtpCreatedAt.Value = DateTime.Now;
            txtImage.Text = "";
            picPreview.Image = null;
            imagePath = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                // Nếu ô tìm kiếm trống, hiển thị tất cả thiết bị
                LoadDevices();
                return;
            }

            // Lọc danh sách thiết bị theo tên hoặc ID
            List<DeviceDTO> filteredList = deviceList.Where(device =>
                device.Name.ToLower().Contains(searchText) ||
                device.DeviceID.ToString().Contains(searchText)
            ).ToList();

            // Tạo DataTable để hiển thị dữ liệu
            DataTable dt = new DataTable();
            dt.Columns.Add("DeviceID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Image", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("CreatedAt", typeof(DateTime));

            // Thêm dữ liệu vào DataTable
            foreach (DeviceDTO device in filteredList)
            {
                string statusText = device.Status == 1 ? "Hoạt động" : "Không hoạt động";
                dt.Rows.Add(device.DeviceID, device.Name, device.Image, statusText, device.CreatedAt);
            }

            dataGridView1.DataSource = dt;

            // Cập nhật hiển thị cho các cột
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string imagePath = row.Cells["Image"].Value?.ToString();
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    try
                    {
                        Image img = Image.FromFile(imagePath);
                        row.Cells["ImagePreview"].Value = img;
                    }
                    catch
                    {
                        row.Cells["ImagePreview"].Value = null;
                    }
                }
            }

            // Định dạng DataGridView
            FormatDataGridView();
        }

        private void DeviceForm_Load(object sender, EventArgs e)
        {
            // Có thể thêm code khởi tạo bổ sung ở đây nếu cần
        }
    }
}