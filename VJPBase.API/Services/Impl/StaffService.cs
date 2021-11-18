using ShoesAPI.Helpers;
using ShoesAPI.Models;
using ShoesAPI.Models.Requests;
using ShoesAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesAPI.Services.Impl
{
    public class StaffService : IStaffService
    {
        private readonly QLBanGiayDbContext _context;

        public StaffService(
            QLBanGiayDbContext context)
        {
            _context = context;
        }

        public List<StaffInfoResponse> GetAllStaff()
        {
            var lst = _context.NhanViens.Select(p =>
                new StaffInfoResponse
                {
                    MaNv = p.MaNv,
                    TenNv = p .TenNv,
                    NgaySinh = p.NgaySinh,
                    GioiTinh = p.GioiTinh,
                    Cmnd = p.Cmnd,
                    DiaChi = p.DiaChi,
                    Sdt = p.Sdt,
                    TaiKhoan = p.TaiKhoan,
                    Password = p.Password,
                    IdchucVu = p.IdchucVu,
                    TenChucVu = p.IdchucVuNavigation.TenChucVu,
                    Luong = p.IdchucVuNavigation.Luong
                }).DefaultIfEmpty().ToList();
            return lst;
        }

        public List<StaffInfoResponse> GetStaffByManager()
        {
            var lst = _context.NhanViens.Where(p => p.IdchucVu == 1).Select(p =>
                new StaffInfoResponse
                {
                    MaNv = p.MaNv,
                    TenNv = p.TenNv,
                    NgaySinh = p.NgaySinh,
                    GioiTinh = p.GioiTinh,
                    Cmnd = p.Cmnd,
                    DiaChi = p.DiaChi,
                    Sdt = p.Sdt,
                    TaiKhoan = p.TaiKhoan,
                    Password = p.Password,
                    IdchucVu = p.IdchucVu,
                    TenChucVu = p.IdchucVuNavigation.TenChucVu,
                    Luong = p.IdchucVuNavigation.Luong
                }).DefaultIfEmpty().ToList();
            return lst;
        }

        public List<StaffInfoResponse> GetStaffByStaff()
        {
            var lst = _context.NhanViens.Where(p => p.IdchucVu == 2).Select(p =>
                new StaffInfoResponse
                {
                    MaNv = p.MaNv,
                    TenNv = p.TenNv,
                    NgaySinh = p.NgaySinh,
                    GioiTinh = p.GioiTinh,
                    Cmnd = p.Cmnd,
                    DiaChi = p.DiaChi,
                    Sdt = p.Sdt,
                    TaiKhoan = p.TaiKhoan,
                    Password = p.Password,
                    IdchucVu = p.IdchucVu,
                    TenChucVu = p.IdchucVuNavigation.TenChucVu,
                    Luong = p.IdchucVuNavigation.Luong
                }).DefaultIfEmpty().ToList();
            return lst;
        }

        public List<StaffInfoResponse> FindStaffName(FindStaffRequest name)
        {
            var lst = GetAllStaff().Where(p => p.TenNv.IndexOf(name.TenNv, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            return lst;
        }

        public bool RemoveStaff(RemoveStaffRequest remove)
        {
            try
            {
                var list = _context.NhanViens.ToList();
                var a = list.Where(p => p.MaNv == remove.MaNv).FirstOrDefault();
                _context.NhanViens.Remove(a);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool CreateStaff(UpdateAddStaffRequest model)
        {
            try
            {
                var staff = new NhanVien()
                {
                    MaNv = model.MaNv,
                    TenNv = model.TenNv,
                    NgaySinh = model.NgaySinh,
                    DiaChi = model.DiaChi,
                    Cmnd = model.Cmnd,
                    Sdt = model.Sdt,
                    TaiKhoan = model.TaiKhoan,
                    Password = model.Password,
                    GioiTinh = model.GioiTinh,
                    IdchucVu = _context.ChucVus.Where(p => p.TenChucVu == model.TenChucVu).Select(p =>p.IdchucVu).FirstOrDefault()                    
                };
                _context.NhanViens.Add(staff);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public List<StaffInfoResponse> UpdateStaffInfo(UpdateAddStaffRequest model)
        {
            var staff = _context.NhanViens.Where(p => p.MaNv == model.MaNv).FirstOrDefault();
            var chucvus = _context.ChucVus.Where(p => p.TenChucVu == model.TenChucVu).FirstOrDefault();

            staff.IdchucVuNavigation = chucvus;
            staff.IdchucVu = chucvus.IdchucVu;

            staff.TenNv = model.TenNv;
            staff.NgaySinh = model.NgaySinh;
            staff.DiaChi = model.DiaChi;
            staff.Cmnd = model.Cmnd;
            staff.Sdt = model.Sdt;
            staff.TaiKhoan = model.TaiKhoan;
            staff.Password = model.Password;
            staff.GioiTinh = model.GioiTinh;

            _context.NhanViens.Update(staff);
            _context.SaveChanges();
            return GetAllStaff();
        }
    }
}
