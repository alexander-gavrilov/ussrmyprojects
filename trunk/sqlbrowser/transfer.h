#ifndef TRANSFER_H
#define TRANSFER_H

#include <QDialog>
#include <QtSql>

//class ConnectionWidget;
//QT_FORWARD_DECLARE_CLASS(QTableView)
//QT_FORWARD_DECLARE_CLASS(QPushButton)
//QT_FORWARD_DECLARE_CLASS(QTextEdit)
//QT_FORWARD_DECLARE_CLASS(QSqlError)

namespace Ui {
    class Transfer;
}

class Transfer : public QDialog {
    Q_OBJECT
public:
    Transfer(QWidget *parent = 0,QAbstractItemModel *source_model=0);
    ~Transfer();

protected:
    void changeEvent(QEvent *e);

private:
    Ui::Transfer *ui;
};

#endif // TRANSFER_H
