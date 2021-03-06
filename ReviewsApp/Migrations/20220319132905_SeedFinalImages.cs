using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsApp.Migrations
{
    public partial class SeedFinalImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            SET IDENTITY_INSERT [dbo].[Images] ON
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (35, N'https://reviewsappimages.blob.core.windows.net/images/3ie4wkti.wdn_xmen03.jpg', 34)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (36, N'https://reviewsappimages.blob.core.windows.net/images/wwlojgg4.jxo_xmen06.jpg', 34)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (37, N'https://reviewsappimages.blob.core.windows.net/images/tsdnx3my.z3l_xmen09.jpg', 34)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (38, N'https://reviewsappimages.blob.core.windows.net/images/i5t42e3g.j0t_xmen10.jpg', 34)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (39, N'https://reviewsappimages.blob.core.windows.net/images/qftug2c3.mgs_xmen14.jpg', 34)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (40, N'https://reviewsappimages.blob.core.windows.net/images/4vyrnsme.nzo_xmen01.jpg', 34)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (41, N'https://reviewsappimages.blob.core.windows.net/images/kglckoad.tzw_1600552.jpeg', 35)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (42, N'https://reviewsappimages.blob.core.windows.net/images/of0iwjb1.njj_1600553.jpeg', 35)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (43, N'https://reviewsappimages.blob.core.windows.net/images/uggtntel.hsb_1600554.jpeg', 35)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (44, N'https://reviewsappimages.blob.core.windows.net/images/vctuyydz.o44_1600556.jpeg', 35)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (45, N'https://reviewsappimages.blob.core.windows.net/images/g04uo0cv.oie_1600557.jpeg', 35)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (50, N'https://reviewsappimages.blob.core.windows.net/images/h5m0nh5m.ssj_1000006.jpeg', 37)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (51, N'https://reviewsappimages.blob.core.windows.net/images/moiqs0jz.4px_1600061.jpeg', 37)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (52, N'https://reviewsappimages.blob.core.windows.net/images/zdlqf1z2.ce1_1600129.jpeg', 37)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (53, N'https://reviewsappimages.blob.core.windows.net/images/tp1srogm.mpl_1600130.jpeg', 37)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (54, N'https://reviewsappimages.blob.core.windows.net/images/200djqus.4nh_1600008.jpeg', 37)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (55, N'https://reviewsappimages.blob.core.windows.net/images/5yxwqvln.f5d_1599703.jpeg', 38)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (56, N'https://reviewsappimages.blob.core.windows.net/images/nvigjfva.n5y_1599765.jpeg', 38)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (57, N'https://reviewsappimages.blob.core.windows.net/images/koztnw1y.oxp_1599838.jpeg', 38)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (58, N'https://reviewsappimages.blob.core.windows.net/images/32pmlg0d.j2m_1599839.jpeg', 38)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (59, N'https://reviewsappimages.blob.core.windows.net/images/lqveadnu.0gh_2598186.jpeg', 39)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (60, N'https://reviewsappimages.blob.core.windows.net/images/qjdtd3zg.34j_0ticket.jpg', 39)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (61, N'https://reviewsappimages.blob.core.windows.net/images/sh5c1m4h.j4f_1film.jpg', 39)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (62, N'https://reviewsappimages.blob.core.windows.net/images/sqpuoafr.ozn_2598185.jpeg', 39)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (65, N'https://reviewsappimages.blob.core.windows.net/images/4phv3e1n.u3l_books.jpg', 41)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (66, N'https://reviewsappimages.blob.core.windows.net/images/h4fn32rc.ka4_glasses.jpg', 41)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (67, N'https://reviewsappimages.blob.core.windows.net/images/3uigqyqf.ev3_old-books.jpg', 41)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (68, N'https://reviewsappimages.blob.core.windows.net/images/foyeumq5.2vj_paper.jpg', 41)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (69, N'https://reviewsappimages.blob.core.windows.net/images/2yfhgaxd.gir_book.jpg', 41)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (70, N'https://reviewsappimages.blob.core.windows.net/images/fu1khcik.szg_reading.jpg', 42)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (71, N'https://reviewsappimages.blob.core.windows.net/images/s0h0isgf.je0_sutterlin.jpg', 42)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (72, N'https://reviewsappimages.blob.core.windows.net/images/fghxtxsk.mwq_book.jpg', 42)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (73, N'https://reviewsappimages.blob.core.windows.net/images/dwtchd2u.ywr_book2.jpg', 42)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (74, N'https://reviewsappimages.blob.core.windows.net/images/xec1f2il.eia_coffee.jpg', 42)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (75, N'https://reviewsappimages.blob.core.windows.net/images/3wk0uj0o.kej_coffee.jpg', 43)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (76, N'https://reviewsappimages.blob.core.windows.net/images/gd1i3uie.e1n_storytelli.jpg', 43)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (77, N'https://reviewsappimages.blob.core.windows.net/images/0tv3zgn1.pxf_writing.jpg', 43)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (78, N'https://reviewsappimages.blob.core.windows.net/images/0a5qnx1j.dzh_book.jpg', 43)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (79, N'https://reviewsappimages.blob.core.windows.net/images/1isockmb.asg_books.jpg', 43)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (80, N'https://reviewsappimages.blob.core.windows.net/images/jcl4p2ez.gav_book.jpg', 44)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (81, N'https://reviewsappimages.blob.core.windows.net/images/mpmau4xi.dfl_books.jpg', 44)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (82, N'https://reviewsappimages.blob.core.windows.net/images/13sk3v2a.k4v_books2.jpg', 44)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (83, N'https://reviewsappimages.blob.core.windows.net/images/glaxufmx.1kq_library.jpg', 44)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (84, N'https://reviewsappimages.blob.core.windows.net/images/y40vfzcz.tfk_bible.jpg', 44)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (85, N'https://reviewsappimages.blob.core.windows.net/images/gccotmlp.0tg_hallelujah.jpg', 45)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (86, N'https://reviewsappimages.blob.core.windows.net/images/fnozzfyg.qjp_mortality.jpg', 45)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (87, N'https://reviewsappimages.blob.core.windows.net/images/fg1nm2sj.ywt_reading.jpg', 45)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (88, N'https://reviewsappimages.blob.core.windows.net/images/j0qg2ala.0kt_atlas.jpg', 45)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (89, N'https://reviewsappimages.blob.core.windows.net/images/zijpy0qc.on2_book.jpg', 45)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (90, N'https://reviewsappimages.blob.core.windows.net/images/pqehr3lx.oe3_playstatio.jpg', 46)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (91, N'https://reviewsappimages.blob.core.windows.net/images/silngnzs.jdk_fortnite.jpg', 46)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (92, N'https://reviewsappimages.blob.core.windows.net/images/t5lnqjl5.huj_game.png', 46)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (93, N'https://reviewsappimages.blob.core.windows.net/images/lsrxqpal.puy_mario.jpg', 46)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (94, N'https://reviewsappimages.blob.core.windows.net/images/5zxv5gz3.4dd_minecraft.jpg', 46)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (95, N'https://reviewsappimages.blob.core.windows.net/images/u5wnkbuj.2xg_portrait.jpg', 47)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (96, N'https://reviewsappimages.blob.core.windows.net/images/c3jd0wol.jvz_computer.jpg', 47)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (97, N'https://reviewsappimages.blob.core.windows.net/images/tofkj3na.kzf_mario.jpg', 47)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (98, N'https://reviewsappimages.blob.core.windows.net/images/i2hnmwgr.5jp_robots.png', 47)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (99, N'https://reviewsappimages.blob.core.windows.net/images/cbojlukz.yiu_among-us.png', 47)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (100, N'https://reviewsappimages.blob.core.windows.net/images/tntp4msd.imv_video-game.jpg', 48)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (101, N'https://reviewsappimages.blob.core.windows.net/images/2uuij0z5.hf0_gaming.jpg', 48)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (102, N'https://reviewsappimages.blob.core.windows.net/images/bhqktplc.qrb_pacman.png', 48)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (103, N'https://reviewsappimages.blob.core.windows.net/images/cduqeshg.io3_yoschi.jpg', 48)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (104, N'https://reviewsappimages.blob.core.windows.net/images/tkdbc3ie.e53_computer-g.jpg', 48)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (105, N'https://reviewsappimages.blob.core.windows.net/images/m2g1pnya.ej4_minecraft.jpg', 49)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (106, N'https://reviewsappimages.blob.core.windows.net/images/fxszusv5.ds1_nes.jpg', 49)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (107, N'https://reviewsappimages.blob.core.windows.net/images/ibvpyryn.g2m_nintendo-s.jpg', 49)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (108, N'https://reviewsappimages.blob.core.windows.net/images/dzntwcxs.0n1_nintendo-s.jpg', 49)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (109, N'https://reviewsappimages.blob.core.windows.net/images/n1kbrdi1.nkn_kids.jpg', 49)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (110, N'https://reviewsappimages.blob.core.windows.net/images/waps45ht.zvp_children.jpg', 50)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (111, N'https://reviewsappimages.blob.core.windows.net/images/ynb25ujy.n00_dice.jpg', 50)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (112, N'https://reviewsappimages.blob.core.windows.net/images/zc4rldpl.t0i_tic-tac-to.jpg', 50)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (113, N'https://reviewsappimages.blob.core.windows.net/images/3oa4vkjd.2vp_chess.jpg', 50)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (114, N'https://reviewsappimages.blob.core.windows.net/images/kfjr4j3m.ifj_chess2.jpg', 50)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (115, N'https://reviewsappimages.blob.core.windows.net/images/eawiebkg.wvj_monkey.jpg', 51)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (116, N'https://reviewsappimages.blob.core.windows.net/images/ew2vdy3p.ibs_piano.jpg', 51)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (117, N'https://reviewsappimages.blob.core.windows.net/images/3zms0k3l.2uo_woman.jpg', 51)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (118, N'https://reviewsappimages.blob.core.windows.net/images/f2kxhq0z.cae_equalizer.png', 51)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (119, N'https://reviewsappimages.blob.core.windows.net/images/g4qyhqqw.loh_guitar.jpg', 51)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (120, N'https://reviewsappimages.blob.core.windows.net/images/zfvcrytl.fft_music.jpg', 52)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (121, N'https://reviewsappimages.blob.core.windows.net/images/ih0q0vna.swf_musician.jpg', 52)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (122, N'https://reviewsappimages.blob.core.windows.net/images/q3rjiedo.oij_tape.jpg', 52)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (123, N'https://reviewsappimages.blob.core.windows.net/images/v3bqvxc4.dtr_audience.jpg', 52)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (124, N'https://reviewsappimages.blob.core.windows.net/images/q5hbwcgk.fha_hand.jpg', 52)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (125, N'https://reviewsappimages.blob.core.windows.net/images/jb3iehss.ddd_saxophone.jpg', 53)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (126, N'https://reviewsappimages.blob.core.windows.net/images/pstdesvs.02s_woman.jpg', 53)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (127, N'https://reviewsappimages.blob.core.windows.net/images/j3ukqjqh.jyb_music.png', 53)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (128, N'https://reviewsappimages.blob.core.windows.net/images/ijlmomnk.1fo_music-play.jpg', 53)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (129, N'https://reviewsappimages.blob.core.windows.net/images/xrn31cqv.s1c_samsung.jpg', 53)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (130, N'https://reviewsappimages.blob.core.windows.net/images/apinw5ln.jvn_record-pla.jpg', 54)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (131, N'https://reviewsappimages.blob.core.windows.net/images/t5rtdqfg.xve_violins.jpg', 54)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (132, N'https://reviewsappimages.blob.core.windows.net/images/voprh1qp.zf5_woman.jpg', 54)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (133, N'https://reviewsappimages.blob.core.windows.net/images/xlnqaqlv.ews_microphone.jpg', 54)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (134, N'https://reviewsappimages.blob.core.windows.net/images/vcxsnftk.xag_music-book.jpg', 54)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (135, N'https://reviewsappimages.blob.core.windows.net/images/aulbrj2b.lld_mobile.jpg', 55)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (136, N'https://reviewsappimages.blob.core.windows.net/images/4juky4rm.mnz_turntable.jpg', 55)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (137, N'https://reviewsappimages.blob.core.windows.net/images/fazmbdhi.ugi_violin.jpg', 55)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (138, N'https://reviewsappimages.blob.core.windows.net/images/b4casvrf.jbg_audio.jpg', 55)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (139, N'https://reviewsappimages.blob.core.windows.net/images/xcwqvjbo.pp4_hands.jpg', 55)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (140, N'https://reviewsappimages.blob.core.windows.net/images/jqy3oo42.w5j_mosaic.jpg', 56)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (141, N'https://reviewsappimages.blob.core.windows.net/images/wrcn1zvn.znm_trees.png', 56)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (142, N'https://reviewsappimages.blob.core.windows.net/images/ohoygu0l.i4c_abstract.jpg', 56)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (143, N'https://reviewsappimages.blob.core.windows.net/images/3rc300tj.rgf_brush.jpg', 56)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (144, N'https://reviewsappimages.blob.core.windows.net/images/yvgfke5e.zd1_red.jpg', 56)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (145, N'https://reviewsappimages.blob.core.windows.net/images/fedfyzth.ppj_fantasy.jpg', 57)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (146, N'https://reviewsappimages.blob.core.windows.net/images/heaon4zo.nnx_painting.jpg', 57)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (147, N'https://reviewsappimages.blob.core.windows.net/images/u5p5md0i.kx3_trees.jpg', 57)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (148, N'https://reviewsappimages.blob.core.windows.net/images/3fvadato.pgp_background.jpg', 57)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (149, N'https://reviewsappimages.blob.core.windows.net/images/odphx2cv.3zx_deer.jpg', 57)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (150, N'https://reviewsappimages.blob.core.windows.net/images/zpqec5at.mph_eye.jpg', 58)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (151, N'https://reviewsappimages.blob.core.windows.net/images/5vlberb3.kpj_flower.jpg', 58)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (152, N'https://reviewsappimages.blob.core.windows.net/images/paakaodk.as5_tiles-shap.jpg', 58)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (153, N'https://reviewsappimages.blob.core.windows.net/images/mjuoj4wn.2f3_abstract.jpg', 58)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (154, N'https://reviewsappimages.blob.core.windows.net/images/n2djlqtm.vw0_colorful.jpg', 58)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (155, N'https://reviewsappimages.blob.core.windows.net/images/42u1ijh1.q4x_color.jpg', 59)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (156, N'https://reviewsappimages.blob.core.windows.net/images/d1yceijx.j3f_abstract2.jpg', 59)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (157, N'https://reviewsappimages.blob.core.windows.net/images/ld3mp2pa.n4g_background.jpg', 59)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (158, N'https://reviewsappimages.blob.core.windows.net/images/gkrtm3cj.bei_background.jpg', 59)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (159, N'https://reviewsappimages.blob.core.windows.net/images/nyk3hs45.y2l_abstract.jpg', 59)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (160, N'https://reviewsappimages.blob.core.windows.net/images/3j3zbfzo.pop_windows.jpg', 60)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (161, N'https://reviewsappimages.blob.core.windows.net/images/jyyadxnp.2ve_background.jpg', 60)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (162, N'https://reviewsappimages.blob.core.windows.net/images/i2a5qek4.u2s_composing.jpg', 60)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (163, N'https://reviewsappimages.blob.core.windows.net/images/4m3mqzk0.osr_mountain.jpg', 60)
            INSERT INTO [dbo].[Images] ([Id], [Url], [ReviewId]) VALUES (164, N'https://reviewsappimages.blob.core.windows.net/images/i0vpqxx3.izn_texture.jpg', 60)
            SET IDENTITY_INSERT [dbo].[Images] OFF
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
