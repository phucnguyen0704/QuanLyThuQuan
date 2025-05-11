using QuanLyThuQuan.BLL;
using QuanLyThuQuan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyThuQuan.Forms
{
    public partial class DeviceForm : Form
    {
        private readonly DeviceBLL deviceBLL;
        private List<DeviceDTO> deviceList;
        private string imagePath = "";
        private bool isEditing = false;

        // Định nghĩa các hằng số trạng thái
        private const int STATUS_AVAILABLE = 1;  // Còn
        private const int STATUS_BORROWED = 2;   // Đã mượn
        private const int STATUS_MAINTENANCE = 3; // Bảo trì

        // Định nghĩa các màu sắc để tái sử dụng
        private static readonly Color HeaderBackColor = Color.FromArgb(51, 51, 76);
        private static readonly Color HeaderForeColor = Color.White;
        private static readonly Color AlternatingRowColor = Color.FromArgb(240, 240, 240);
        private static readonly Color StatusAvailableColor = Color.FromArgb(40, 167, 69); // Màu xanh lá
        private static readonly Color StatusBorrowedColor = Color.FromArgb(255, 193, 7);  // Màu vàng
        private static readonly Color StatusMaintenanceColor = Color.FromArgb(220, 53, 69); // Màu đỏ

        public DeviceForm()
        {
            deviceBLL = new DeviceBLL();

            InitializeComponent();
            InitializeComboBoxes();

            LoadDevices();

            dataGridView1.CellFormatting += DataGridView1_CellFormatting;

            SwitchToViewMode();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                e.CellStyle.ForeColor = HeaderForeColor;

                switch (status)
                {
                    case "Còn":
                        e.CellStyle.BackColor = StatusAvailableColor;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "Đã mượn":
                        e.CellStyle.BackColor = StatusBorrowedColor;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "Bảo trì":
                        e.CellStyle.BackColor = StatusMaintenanceColor;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    default:
                        e.CellStyle.BackColor = Color.White;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void InitializeComboBoxes()
        {
            SetupStatusComboBox();
            SetupSearchCategoryComboBox();
        }

        private void SetupStatusComboBox()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new string[] { "Còn", "Đã mượn", "Bảo trì" });
            cboStatus.SelectedIndex = 0;
        }

        private void SetupSearchCategoryComboBox()
        {
            cboSearchCategory.Items.Clear();
            cboSearchCategory.Items.AddRange(new string[]
            {
                "Tất cả",
                "Mã thiết bị",
                "Tên thiết bị",
                "Trạng thái",
                "Mã thành viên",
                "Mã ghế",
                "Loại đặt chỗ"
            });
            cboSearchCategory.SelectedIndex = 0;
        }

        private void LoadDevices()
        {
            try
            {
                deviceList = deviceBLL.getAll();
                if (deviceList == null)
                {
                    MessageBox.Show("Không thể tải dữ liệu thiết bị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt = CreateDeviceDataTable(deviceList);
                dataGridView1.DataSource = dt;

                ConfigureDataGridViewColumns();
                AddImagePreviewColumn();
                LoadImagesForRows();
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu thiết bị: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable CreateDeviceDataTable(List<DeviceDTO> devices)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DeviceID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Image", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("CreatedAt", typeof(DateTime));

            foreach (DeviceDTO device in devices)
            {
                dt.Rows.Add(
                    device.DeviceID,
                    device.Name,
                    device.Image,
                    GetStatusText(device.Status),
                    device.CreatedAt
                );
            }

            return dt;
        }

        private string GetStatusText(int status)
        {
            switch (status)
            {
                case STATUS_AVAILABLE: return "Còn";
                case STATUS_BORROWED: return "Đã mượn";
                case STATUS_MAINTENANCE: return "Bảo trì";
                default: return "Không xác định";
            }
        }

        private int GetStatusValue(string statusText)
        {
            switch (statusText)
            {
                case "Còn": return STATUS_AVAILABLE;
                case "Đã mượn": return STATUS_BORROWED;
                case "Bảo trì": return STATUS_MAINTENANCE;
                default: return STATUS_AVAILABLE;
            }
        }

        private void ConfigureDataGridViewColumns()
        {
            dataGridView1.Columns["DeviceID"].HeaderText = "Mã thiết bị";
            dataGridView1.Columns["Name"].HeaderText = "Tên thiết bị";
            dataGridView1.Columns["Image"].HeaderText = "Hình ảnh";
            dataGridView1.Columns["Status"].HeaderText = "Trạng thái";
            dataGridView1.Columns["CreatedAt"].HeaderText = "Ngày tạo";

            dataGridView1.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["Image"].Visible = false;
        }

        private void AddImagePreviewColumn()
        {
            if (!dataGridView1.Columns.Contains("ImagePreview"))
            {
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                {
                    HeaderText = "Hình ảnh",
                    Name = "ImagePreview",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dataGridView1.Columns.Add(imgColumn);
            }
        }


        private void LoadImagesForRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string imagePath = row.Cells["Image"].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(imagePath) && !Path.IsPathRooted(imagePath))
                {
                    string fullPath = Path.Combine(Application.StartupPath, imagePath);

                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                            {
                                row.Cells["ImagePreview"].Value = Image.FromStream(fs);
                            }
                        }
                        catch
                        {
                            row.Cells["ImagePreview"].Value = null;
                        }
                    }
                    else
                    {
                        row.Cells["ImagePreview"].Value = null;
                    }
                }
                else
                {
                    row.Cells["ImagePreview"].Value = null;
                }
            }
        }

        private void FormatDataGridView()
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = HeaderBackColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = HeaderForeColor;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 40;

            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9.75F);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = AlternatingRowColor;

            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.FromArgb(230, 230, 230);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
                return;

            int deviceID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["DeviceID"].Value);
            DeviceDTO selectedDevice = deviceList.FirstOrDefault(d => d.DeviceID == deviceID);

            if (selectedDevice != null)
            {
                PopulateFormFields(selectedDevice);
                SwitchToViewMode();
            }
        }

        private void PopulateFormFields(DeviceDTO device)
        {
            txtDeviceID.Text = device.DeviceID.ToString();
            txtName.Text = device.Name;
            cboStatus.SelectedIndex = device.Status - 1;
            dtpCreatedAt.Value = device.CreatedAt;
            txtImage.Text = device.Image;

            LoadImagePreview(device.Image);
            imagePath = "";
        }

        private void LoadImagePreview(string relativePath)
        {
            picPreview.Image = null;

            if (string.IsNullOrWhiteSpace(relativePath)) return;

            string absolutePath = Path.Combine(Application.StartupPath, relativePath);

            if (File.Exists(absolutePath))
            {
                try
                {
                    using (Image img = Image.FromFile(absolutePath))
                    {
                        picPreview.Image = new Bitmap(img);
                    }
                }
                catch
                {
                    picPreview.Image = null;
                }
            }
        }

        private void SwitchToViewMode()
        {
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;
            isEditing = false;

            txtName.Enabled = false;
            cboStatus.Enabled = false;
            btnBrowse.Enabled = false;
        }

        private void SwitchToAddMode()
        {
            btnAdd.Visible = false;
            btnSave.Visible = true;
            btnEdit.Visible = false;
            btnDelete.Visible = false;

            txtName.Enabled = true;
            cboStatus.SelectedIndex = 0;
            cboStatus.Enabled = false;
            btnBrowse.Enabled = true;
        }

        private void SwitchToEditMode()
        {
            btnAdd.Visible = false;
            btnSave.Visible = true;
            btnEdit.Visible = false;
            btnDelete.Visible = false;

            txtName.Enabled = true;
            cboStatus.Enabled = true;
            btnBrowse.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            isEditing = false;
            SwitchToAddMode();

            txtName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDeviceID.Text))
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditing = true;
            SwitchToEditMode();
            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                string finalImagePath = ProcessImage();
                DeviceDTO device = CreateDeviceFromForm(finalImagePath);
                bool result = SaveDevice(device);

                if (result)
                {

                    LoadDevices();
                    ClearForm();
                    SwitchToViewMode();

                    int selectedDeviceID = device.DeviceID;
                    if (selectedDeviceID != 0)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow && row.Cells["DeviceID"].Value != null &&
                                (int)row.Cells["DeviceID"].Value == selectedDeviceID)
                            {
                                row.Selected = true;
                                dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (dataGridView1.Rows.Count > 0)
                        {
                            int lastIndex = dataGridView1.Rows.Count - 1;
                            if (!dataGridView1.Rows[lastIndex].IsNewRow)
                            {
                                dataGridView1.Rows[lastIndex].Selected = true;
                                dataGridView1.FirstDisplayedScrollingRowIndex = lastIndex;
                            }
                        }
                    }

                    loadFormFromSelectRow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thiết bị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            return true;
        }

        private string ProcessImage()
        {
            string finalImagePath = txtImage.Text;

            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    string fileName = Path.GetFileName(imagePath);
                    string relativeFolder = Path.Combine("Resources", "Images");
                    string absoluteFolder = Path.Combine(Application.StartupPath, relativeFolder);
                    string destPath = Path.Combine(absoluteFolder, fileName);

                    Directory.CreateDirectory(absoluteFolder);
                    File.Copy(imagePath, destPath, true);

                    finalImagePath = Path.Combine(relativeFolder, fileName).Replace("\\", "/");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý hình ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return finalImagePath;
        }

        private DeviceDTO CreateDeviceFromForm(string imagePath)
        {
            int deviceID = isEditing ? int.Parse(txtDeviceID.Text) : 0;
            int status = cboStatus.SelectedIndex + 1;

            return new DeviceDTO(
                deviceID,
                txtName.Text,
                imagePath,
                status,
                dtpCreatedAt.Value
            );
        }

        private bool SaveDevice(DeviceDTO device)
        {
            bool result = isEditing ? deviceBLL.update(device) : deviceBLL.create(device);
            string action = isEditing ? "Cập nhật" : "Thêm";

            if (result)
            {
                MessageBox.Show($"{action} thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"{action} thiết bị thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

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
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa thiết bị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
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
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp",
                Title = "Chọn hình ảnh thiết bị"
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;
                    txtImage.Text = imagePath;
                    LoadImagePreview(imagePath);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadDevices();
            //ClearForm();
            SwitchToViewMode();
            loadFormFromSelectRow();
        }

        private void ClearForm()
        {
            txtDeviceID.Text = "";
            txtName.Text = "";
            cboStatus.SelectedIndex = 0;
            dtpCreatedAt.Value = DateTime.Now;
            txtImage.Text = "";
            if (picPreview.Image != null)
            {
                picPreview.Image.Dispose();
                picPreview.Image = null;
            }
            imagePath = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadDevices();
                return;
            }

            List<DeviceDTO> filteredList = FilterDevices(searchText);
            DisplayFilteredDevices(filteredList);
        }

        private List<DeviceDTO> FilterDevices(string searchText)
        {
            if (deviceList == null)
                return new List<DeviceDTO>();

            switch (cboSearchCategory.SelectedIndex)
            {
                case 0: // Tất cả
                    return deviceList.Where(device =>
                        device.DeviceID.ToString().Contains(searchText) ||
                        device.Name.ToLower().Contains(searchText) ||
                        GetStatusText(device.Status).ToLower().Contains(searchText)
                    ).ToList();

                case 1: // Mã thiết bị
                    return deviceList.Where(device =>
                        device.DeviceID.ToString().Contains(searchText)
                    ).ToList();

                case 2: // Tên thiết bị
                    return deviceList.Where(device =>
                        device.Name.ToLower().Contains(searchText)
                    ).ToList();

                case 3: // Trạng thái
                    return deviceList.Where(device =>
                        GetStatusText(device.Status).ToLower().Contains(searchText)
                    ).ToList();

                default:
                    return deviceList; // Các trường hợp Mã thành viên, Mã ghế, Loại đặt chỗ chưa được triển khai
            }
        }

        private void DisplayFilteredDevices(List<DeviceDTO> filteredList)
        {
            DataTable dt = CreateDeviceDataTable(filteredList);
            dataGridView1.DataSource = dt;
            LoadImagesForRows();
            FormatDataGridView();
        }

        private void cboSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch_TextChanged(sender, e);
        }

        private void loadFormFromSelectRow()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int deviceID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["DeviceID"].Value);
                DeviceDTO selectedDevice = deviceList.FirstOrDefault(d => d.DeviceID == deviceID);

                if (selectedDevice != null)
                {
                    PopulateFormFields(selectedDevice);
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            loadFormFromSelectRow();
            SwitchToViewMode();
        }

        private void DeviceForm_Load(object sender, EventArgs e)
        {
            LoadImagesForRows();
        }
    }
}