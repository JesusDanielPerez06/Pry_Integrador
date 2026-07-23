using pry_integrador.Properties;
using pry_integrador.UserControl;
using pry_integrador.Medicos.Gestion_de_medicos;
using pry_integrador.Medicos.Registro_de_medicos;
using pry_integrador.Pruebas;
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

namespace pry_integrador
{
    public partial class FormPrincipal : Form
    {
        private void CargarVista(Form formulario)
        {
            panelForms.Controls.Clear();
            formulario.TopLevel = false;        
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;  
            panelForms.Controls.Add(formulario);
            formulario.Show();
        }
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btn_inicio_MouseHover(object sender, EventArgs e)
        {
            btn_inicio.Image = Resources.in_blue;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btn_inicio_MouseLeave(object sender, EventArgs e)
        {
            btn_inicio.Image = Resources.inicio_png;
        }

        private void btn_Agenda_MouseHover(object sender, EventArgs e)
        {
            btn_Agenda.Image = Resources.ag_blue;
        }

        private void btn_Agenda_MouseLeave(object sender, EventArgs e)
        {
            btn_Agenda.Image = Resources.age_png;
        }

        private void btn_pacientes_Click(object sender, EventArgs e)
        {

        }

        private void btn_pacientes_MouseHover(object sender, EventArgs e)
        {
            btn_pacientes.Image = Resources.pa_blue;
        }

        private void btn_pacientes_MouseLeave(object sender, EventArgs e)
        {
            btn_pacientes.Image = Resources.pacientes_png;
        }

        private void btn_medicos_MouseHover(object sender, EventArgs e)
        {
            btn_medicos.Image = Resources.med_blue;
        }

        private void btn_medicos_MouseLeave(object sender, EventArgs e)
        {
            btn_medicos.Image = Resources.medi_png;
        }

        private void btn_consultorios_MouseHover(object sender, EventArgs e)
        {
            btn_consultorios.Image = Resources.cons_blue;
        }

        private void btn_consultorios_MouseLeave(object sender, EventArgs e)
        {
            btn_consultorios.Image = Resources.consultorios_png;
        }

        private void btn_especialidades_MouseHover(object sender, EventArgs e)
        {
            btn_especialidades.Image = Resources.espe_blue;
        }

        private void btn_especialidades_MouseLeave(object sender, EventArgs e)
        {
            btn_especialidades.Image = Resources.especialidades_png;
        }

        private void btn_reportes_MouseHover(object sender, EventArgs e)
        {
            btn_reportes.Image = Resources.repo_blue;
        }

        private void btn_reportes_MouseLeave(object sender, EventArgs e)
        {
            btn_reportes.Image = Resources.reportes_png;
        }

        private void btn_recordatorios_MouseHover(object sender, EventArgs e)
        {
            btn_recordatorios.Image = Resources.recorda_blue;
        }

        private void btn_recordatorios_MouseLeave(object sender, EventArgs e)
        {
            btn_recordatorios.Image = Resources.recordatorios_png;
        }

        private void btn_mensajes_MouseHover(object sender, EventArgs e)
        {
            btn_mensajes.Image = Resources.msj_blue;
        }

        private void btn_mensajes_MouseLeave(object sender, EventArgs e)
        {
            btn_mensajes.Image = Resources.mensajes_png;
        }

        private void btn_configuracion_MouseHover(object sender, EventArgs e)
        {
            btn_configuracion.Image = Resources.conf_blue;
        }

        private void btn_configuracion_MouseLeave(object sender, EventArgs e)
        {
            btn_configuracion.Image = Resources.confi_png;
        }

        private void btn_ayuda_MouseHover(object sender, EventArgs e)
        {
            btn_ayuda.Image = Resources.ayuda_blue;
        }

        private void btn_ayuda_MouseLeave(object sender, EventArgs e)
        {
            btn_ayuda.Image = Resources.ayuda_png;
        }

        private void btn_cerrar_Sesion_MouseHover(object sender, EventArgs e)
        {
            btn_cerrar_Sesion.Image = Resources.cierra_blue;
        }

        private void btn_cerrar_Sesion_MouseLeave(object sender, EventArgs e)
        {
            btn_cerrar_Sesion.Image = Resources.cerrar_png;
        }

        private void btn_Agenda_Click(object sender, EventArgs e)
        {
            CargarVista(new FormAgendaCitas());
        }

        private void btn_medicos_Click(object sender, EventArgs e)
        {
            CargarVista(new FormGestionMedicos());
        }
            


        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_ayuda_Click(object sender, EventArgs e)
        {
            CargarVista(new FormHelp());
        }

        private void btn_cerrar_Sesion_Click(object sender, EventArgs e)
        {
            FormCerrarSesion formCerrar = new FormCerrarSesion();
            formCerrar.StartPosition = FormStartPosition.CenterScreen;
            formCerrar.ShowDialog();
        }
    }
}
