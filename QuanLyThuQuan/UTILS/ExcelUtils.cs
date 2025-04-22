using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using QuanLyThuQuan.DTO;
using System.Net.Mail;

namespace QuanLyThuQuan.Utils
{
    internal static class ExcelUtils
    {
        public static bool ExportToCsv(DataGridView dataGridView, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            // Thêm tiêu đề cột
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                sb.Append(dataGridView.Columns[i].HeaderText);
                if (i < dataGridView.Columns.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.AppendLine();

            // Thêm dữ liệu từng dòng
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow) // Bỏ qua dòng mới nếu có
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        sb.Append(row.Cells[i].Value?.ToString()?.Replace(',', ' ')); // Xử lý dấu phẩy trong dữ liệu
                        if (i < row.Cells.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.AppendLine();
                }
            }

            try
            {
                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true; // Trả về true nếu thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Trả về false nếu có lỗi
            }
        }

        public static List<MemberDTO> ImportFromExcel(string filePath)
        {
            List<MemberDTO> danhSachNhap = new List<MemberDTO>();
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                FileInfo excelFile = new FileInfo(filePath);

                using (ExcelPackage excelPackage = new ExcelPackage(excelFile))
                {
                    if (excelPackage.Workbook.Worksheets.Count > 0)
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension?.Rows ?? 0;
                        int colCount = worksheet.Dimension?.Columns ?? 0; // Lấy số lượng cột

                        // Xác định vị trí cột (tùy thuộc vào file Excel của bạn)
                        int hoTenCol = 1;
                        int ngaySinhCol = 2;
                        int emailCol = 3;
                        int usernameCol = 4;
                        int passwordCol = 5;
                        // Thêm các cột khác nếu có

                        for (int row = 2; row <= rowCount; row++)
                        {
                            MemberDTO tv = new MemberDTO();
                            bool duLieuHopLe = true;

                            try
                            {
                                tv.FullName = worksheet.Cells[row, hoTenCol].Value?.ToString()?.Trim();
                                if (string.IsNullOrEmpty(tv.FullName)) duLieuHopLe = false;

                                DateTime birthday;
                                DateTime.TryParse(worksheet.Cells[row, ngaySinhCol].Value?.ToString(), out birthday);
                                tv.Birthday = birthday;

                                tv.Email = worksheet.Cells[row, emailCol].Value?.ToString()?.Trim();
                                if (!string.IsNullOrEmpty(tv.Email) && !IsValidEmail(tv.Email)) duLieuHopLe = false;

                                tv.Username = worksheet.Cells[row, usernameCol].Value?.ToString()?.Trim();
                                tv.Password = worksheet.Cells[row, passwordCol].Value?.ToString()?.Trim();

                                // Đọc các cột khác tùy theo file Excel của bạn
                                // Ví dụ:
                                // tv.Role = worksheet.Cells[row, 6].Value?.ToString()?.Trim();
                                // if (int.TryParse(worksheet.Cells[row, 7].Value?.ToString(), out int status))
                                // {
                                //     tv.Status = status;
                                // }

                                if (duLieuHopLe)
                                {
                                    danhSachNhap.Add(tv);
                                }
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine($"Lỗi khi đọc dòng {row}: {ex.Message}");
                                // Bạn có thể quyết định có muốn bỏ qua dòng lỗi hay không
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return danhSachNhap;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}